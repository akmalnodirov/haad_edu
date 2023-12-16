using Grpc.Net.Client;
using GrpcClient;


using var channel = GrpcChannel.ForAddress("http://localhost:5029");

var client = new Greeter.GreeterClient(channel);

Console.Write("Введите имя: ");
string? name = Console.ReadLine();

var reply = await client.SayHelloAsync(new HelloRequest { Baby = name });

Console.WriteLine($"Ответ сервера: {reply.Message}");

Console.ReadKey();