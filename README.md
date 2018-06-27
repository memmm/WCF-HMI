# WCF-HMI
Would it be beneficial to rewrite the HMI as client-service app? - Feasibility study

Introduction

This study aims to explore if it is feasible to redevelop the company’s existing system in the following manner: 

The system is based on client-service architecture, utilizing the WCF framework
The model behind the service is described in setting files
Multiple HMI (as clients) connect to the service, communicating with callbacks/events
A web-based ASP.NET HMI can be connected to the system as client as well as a WPF application

The prototype
The developed prototype has the following specifications:
The service contains hard-coded objects, that consists the model.
Two types of client connect to the service: An ASP.NET Core website and a WPF application, multiple instances of both can connect to the service.
The data is shown on both platform and can be modified in a way the changes appear on all client and modify the setting file.




Alternatives
	Socket.io - enables real-time bidirectional event-based communication. Advantages: Shorter learning curve than WCF
Modern, widely used
Disadvantages:
Requires Node.js to implement service
Client needs extra framework (eg. SocketIO4Net, SocketIOClientDotNet)

