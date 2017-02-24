# NativeAPI-DotNet-Demo
This C# .Net Application is Intended to be used as sandbox / sample code when consuming Sabre Native API Services. Acting as Client.
# Foreground
The Sabre Native API enables third party applications to consume services and interact with SRW Runtime Services.
The design of Native API is based on open source JMS and ActiveMQ technologies, so it's easy to find documentation and client libraries for different languages.

In order to implement the message "broker", a NativeAPI Bridge RedApp must be build and enabled_*_ on Sabre Red Workspace Runtime, so u can connect your client app and consume the services.
_* U will find the RedApp plugin project on the folder NativeAPI-Bridge-RedApp at root of this project._


#Dependencies
The Sample C# App presented here uses Apache.NMS implementation of ActiveMQ Provider to connect to Native API Bridge RedApp, http://activemq.apache.org/nms/nms.html, which, depends on ActiveMQ implementation http://activemq.apache.org


#License

Copyright (c) 2014 Sabre Corp Licensed under the MIT license.

#Disclaimer of Warranty and Limitation of Liability

This software and any compiled programs created using this software are furnished “as is” without warranty of any kind, including but not limited to the implied warranties of merchantability and fitness for a particular purpose. No oral or written information or advice given by Sabre, its agents or employees shall create a warranty or in any way increase the scope of this warranty, and you may not rely on any such information or advice. Sabre does not warrant, guarantee, or make any representations regarding the use, or the results of the use, of this software, compiled programs created using this software, or written materials in terms of correctness, accuracy, reliability, currentness, or otherwise. The entire risk as to the results and performance of this software and any compiled applications created using this software is assumed by you. Neither Sabre nor anyone else who has been involved in the creation, production or delivery of this software shall be liable for any direct, indirect, consequential, or incidental damages (including damages for loss of business profits, business interruption, loss of business information, and the like) arising out of the use of or inability to use such product even if Sabre has been advised of the possibility of such damages.
