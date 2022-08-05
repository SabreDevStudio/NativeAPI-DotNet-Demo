using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using System.Threading;
using System.Xml;
using System.Xml.XPath;

namespace NativeAppWin
{
    public partial class FormMain : Form
    {
        private static String RQ_QUEUE_SUFFIX = "_request";
        private static String RS_QUEUE_SUFFIX = "_response";

        private bool isListening = false;

        protected static AutoResetEvent semaphore = new AutoResetEvent(false);
        protected static ITextMessage message = null;
        protected static TimeSpan rcvTimeout = TimeSpan.FromSeconds(10);

        private IConnection connection;
        private ISession session;
        private IDestination destinationRQ;
        private IDestination destinationRS;
        IMessageProducer producer;
        IMessageConsumer consumer;

        private int totMsgSent = 0;
        private int totMsgReceived = 0;

        protected String athID = null;
        protected static List<String> msgCache = new List<string>();
        protected static Dictionary<String, String> msgsCache = new Dictionary<string, string>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void StartSession()
        {
            // authentication data to connect to NativeAPI Bridge RedApp (ActiveMQ Broker)
            String user = "admin";
            String password = "password";
            String host = "localhost";
            int port = int.Parse("61616");
            String redAppID = "com.company.app.goes.here";  // from your eclipse workspace, project
            String userID = System.Environment.GetEnvironmentVariable("USERNAME");
            String domainID = System.Environment.GetEnvironmentVariable("USERDOMAIN");

            // Create connection
            Uri connectUri = new Uri("activemq:tcp://" + host + ":" + port);
            IConnectionFactory factory = new NMSConnectionFactory(connectUri);
            connection = factory.CreateConnection(user, password);
            connection.Start();

            //Start a session
            session = connection.CreateSession();

            //Get address for request / reponse queues
            destinationRQ = SessionUtil.GetDestination(session, redAppID + "_" + domainID + "\\" + userID + RQ_QUEUE_SUFFIX);
            destinationRS = SessionUtil.GetDestination(session, redAppID + "_" + domainID + "\\" + userID + RS_QUEUE_SUFFIX);

            // create request producer
            producer = session.CreateProducer(destinationRQ);
            producer.DeliveryMode = MsgDeliveryMode.Persistent;

            // create a consumee for responses queue, would receive and "parse" all messages from Bridge RedApp
            // note that it will work "assynchronously", that is, the broker can "push" messages to client, without need to "pool"
            consumer = session.CreateConsumer(destinationRS);
            consumer.Listener += new MessageListener(onMessageAuto);
        }

        private String getSessionTokenRQ()
        {
            String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><com.sabre.edge.dynamo.nativeapi:GetSessionSecurityTokenRQ xmlns:com.sabre.edge.dynamo.nativeapi=\"http://stl.sabre.com/POS/SRW/NextGen/nativeapi/v1.0\"/>";
            return body;
        }

        private String executeInEmuRQ(String pCommand)
        {
            String body = "<?xml version = \"1.0\" encoding = \"UTF-8\" ?><com.sabre.edge.dynamo.nativeapi:ExecuteInEmuRQ xmlns:com.sabre.edge.dynamo.nativeapi=\"http://stl.sabre.com/POS/SRW/NextGen/nativeapi/v1.0\" showCommand=\"" + (this.checkBoxShowCmd.Checked ? "true" : "false") + "\" showResponse=\"" + (this.checkBox2.Checked ? "true" : "false") + "\"><Command>" + pCommand + "</Command></com.sabre.edge.dynamo.nativeapi:ExecuteInEmuRQ>";
            return body;
        }

        private String eventSubscriptionRQ()
        {
            String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><com.sabre.edge.dynamo.nativeapi:EventSubscriptionRQ xmlns:com.sabre.edge.dynamo.nativeapi=\"http://stl.sabre.com/POS/SRW/NextGen/nativeapi/v1.0\"><com.sabre.edge.dynamo.nativeapi:event eventName=\"EMU_RESPONSE\" state=\"PRE\" /></com.sabre.edge.dynamo.nativeapi:EventSubscriptionRQ>";
            return body;
        }

        private String commandtSubscriptionRQ()
        {
            String body = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><ns1:CommandSubscriptionRQ xmlns:ns1 =\"http://stl.sabre.com/POS/SRW/NextGen/nativeapi/v1.0\"/>";
            return body;
        }

        private String commandInterceptionRS(String pCommand)
        {
            String body = "<?xml version = \"1.0\" encoding = \"UTF-8\" ?><com.sabre.edge.dynamo.nativeapi:CommandInterceptionRS xmlns:com.sabre.edge.dynamo.nativeapi=\"http://stl.sabre.com/POS/SRW/NextGen/nativeapi/v1.0\" command = \"" + pCommand + "\" />";
            return body;
        }

        private void EndSession()
        {
            consumer.Close();
            producer.Close();
            session.Close();
            connection.Close();
        }

        private void stopListening()
        {
            consumer.Close();
            consumer.Listener -= null;
        }

        private void startListening()
        {
            SendMessage(eventSubscriptionRQ());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartSession();
        }

        private void Form1_FormClosed(object sender, EventArgs e)
        {
            EndSession();
        }

        private void SendMessage(String body)
        {
            ITextMessage msg = session.CreateTextMessage(body);
            producer.Send(msg);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(body);
            String rootName = doc.DocumentElement.Name;
            totMsgSent++;
            String msgID = "out->" + totMsgSent + "-" + rootName;
            cacheMsgs(msgID, msg.Text);

        }

        protected void onMessageAuto(IMessage rcvdMsg)
        {
            ITextMessage tmpmessage = rcvdMsg as ITextMessage;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(tmpmessage.Text);

            String rootName = doc.DocumentElement.Name;
            totMsgReceived++;
            String msgID = "in<-" + totMsgReceived + "-" + rootName;

            cacheMsgs(msgID, tmpmessage.Text);
        }

        private void cacheMsgs(String msgID,String msgText)
        {
            msgsCache.Add(msgID, msgText);
            addMsgList(msgID);
        }

        delegate void refreshCountCb(String text);
        private void refreshCount(String text)
        {
            if (this.groupBox1.InvokeRequired)
            {
                refreshCountCb cb = new refreshCountCb(refreshCount);
                this.groupBox1.Invoke(cb,new object[] { text });
            }
            else
            {
                this.groupBox1.Text = text;
            }
        }

        delegate void refreshListCb(List<String> msgs);
        private void refreshList(List<String> msgs)
        {
            if (this.listBoxMessages.InvokeRequired)
            {
                refreshListCb cb = new refreshListCb(refreshList);
                this.listBoxMessages.Invoke(cb, new object[] { msgs });
            }
            else
            {
                this.listBoxMessages.Items.Clear();
                int tam = msgCache.Count;
                int i = 0;
                for (i = 0; i < tam; i++)
                {
                    this.listBoxMessages.Items.Add("Item" + i);
                }
            }
        }

        delegate void addMsgListCb(String msgID);
        private void addMsgList(String msgID)
        {
            if (this.listBoxMessages.InvokeRequired)
            {
                addMsgListCb cb = new addMsgListCb(addMsgList);
                this.listBoxMessages.Invoke(cb, new object[] { msgID });
            }
            else
            {
                this.listBoxMessages.Items.Add(msgID);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxMessages.SelectedIndex >= 0)
            {
                this.richTextBoxMessageDetail.Clear();
                String msgID = this.listBoxMessages.GetItemText(this.listBoxMessages.GetItemText(this.listBoxMessages.SelectedItem));

                if (msgsCache.ContainsKey(msgID))
                    this.richTextBoxMessageDetail.Text = msgsCache[msgID];
                else
                    this.richTextBoxMessageDetail.Text = "";
            }
        }

        private void buttonStartListening_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                startListening();
                this.buttonStartListening.Text = "listening Events";
            }

            isListening = !isListening;
        }


        private void buttonGetToken_Click(object sender, EventArgs e)
        {
            SendMessage(getSessionTokenRQ());
        }


        private void buttonSendEmuCmd_Click(object sender, EventArgs e)
        {
            SendMessage(executeInEmuRQ(this.textBoxSendEmuCmd.Text));
        }

        private void buttonCmdSubscribe_Click(object sender, EventArgs e)
        {
            SendMessage(commandtSubscriptionRQ());
        }

        private void buttonCmdInterceptionRS_Click(object sender, EventArgs e)
        {
            SendMessage(commandInterceptionRS(this.textBoxCmdInterception.Text));
        }

    }
}
