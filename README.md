# natstest
Test for NATS queue

## Requirements
Docker - needed to run a NATS message queue server

## NATS Server
Start a NATS message queue server in a Docker container using 

`docker run -d -p 4222:4222 -p 8222:8222 -p 6222:6222 --name gnatsd -ti nats:latest`

## Projects
Build and run the server project:
```
cd natsserver
dotnet build
dotnet run
```

In a separate command window, build and run the client project:
```
cd natsclient
dotnet build
dotnet run
```

The client should publish a message to a NATS queue and the server should receive the message and display the contents.
TEST2