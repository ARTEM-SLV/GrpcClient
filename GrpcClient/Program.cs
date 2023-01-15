using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string str = "";
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            while (str != "Пока")
            {
                Console.WriteLine("Введите имя и нажмите Enter для продолжения....");
                str = Console.ReadLine();                
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(new HelloRequest { Name = str });
                Console.WriteLine($"Сервер: { reply.Message}");
            }

        }
    }
}
