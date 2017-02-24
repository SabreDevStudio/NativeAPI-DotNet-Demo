# NativeAPI-DotNet-Demo
This C# .Net Application is Intended to be used as sandbox / sample code when consuming Sabre Native API Services. Acting as Client.
# Foreground
The Sabre Native API enables third party applications to consume services and interact with SRW Runtime Services.
The design of Native API is based on open source JMS and ActiveMQ technologies, so it's easy to find documentation and client libraries for different languages.

In order to implement the message "broker", a NativeAPI Bridge RedApp must be build and enabled on Sabre Red Workspace Runtime, so u can connect your client app and consume the services.

#Dependencies
The Sample C# App presented here uses Apache.NMS implementation of ActiveMQ Provider to connect to Native API Bridge RedApp, http://activemq.apache.org/nms/nms.html, which, depends on ActiveMQ implementation http://activemq.apache.org
