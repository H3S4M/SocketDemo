using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using TcpClient client = new TcpClient();
        await client.ConnectAsync("127.0.0.1", 5000);
        Console.WriteLine("Connected to server.");

        using NetworkStream stream = client.GetStream();

        byte[] data = Encoding.UTF8.GetBytes("Hello Server!");
        await stream.WriteAsync(data, 0, data.Length);

        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

        Console.WriteLine("Received: " + Encoding.UTF8.GetString(buffer, 0, bytesRead));

        Console.ReadLine();
    }
}