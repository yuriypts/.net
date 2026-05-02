#gRPC

gRPC is a high-performance RPC (Remote Procedure Call) framework originally developed by Google. It lets a client call methods on a remote server 
as if they were local functions, abstracting away HTTP, serialization, and networking details.

At its core, gRPC combines:

HTTP/2 → multiplexed, persistent connections, low latency
Protocol Buffers (Protobuf) → compact binary serialization
Strongly-typed contracts defined in .proto files



1. gRPC protofile are the way you define the contract between the client and the server. It defines the service, the methods, and the messages that are used in the communication.

2. The protofile is used to generate code for both the client and the server. The generated code includes the service interface, the message classes, and the gRPC client and server stubs.

3. When to use?
   - Use gRPC when you need high performance, low latency, and efficient communication between services. It is ideal for microservices architecture, real-time communication,
and scenarios where you need to support multiple languages.
   - Use REST when you need simplicity, wide compatibility, and ease of use. It is ideal for public APIs, web applications, and scenarios where you need to support a wide range of clients.
	
4. gRPC vs REST:
   - gRPC uses HTTP/2 and Protobuf, while REST typically uses HTTP/1.1 and JSON.
   - gRPC is more efficient and faster than REST, but it can be more complex to set up and use.
   - REST is more widely supported and easier to use, but it may not be suitable for high-performance scenarios.

5. (close to WebSocket) gRPC is two way binding, meaning that both the client and the server can send messages to each other. This allows for more efficient communication 
and can reduce latency. REST, on the other hand, is typically one way binding, where the client sends a request to the server and waits for a response.
	- 
 In summary, gRPC is a powerful framework for building high-performance, efficient communication between services, while REST is a simpler and more widely supported approach for building APIs. The choice between the two depends on your specific use case and requirements.