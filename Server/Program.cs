using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    private TcpListener listener;

    public Server()
    {
        listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();
        Console.WriteLine("Сервер запущен и ожидает подключения...");
    }

    public void Start()
    {
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Клиент подключен");
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    private void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        while (true)
        {
            try
            {
                DateTime thisDay = DateTime.Now;
                string stringDay = thisDay.ToString();
                int even = 0; // чётные
                int odd = 0; // нечетные
                string message;
                foreach (var item in stringDay)
                    try
                    {
                        int value = int.Parse(Convert.ToString(item));
                        if (value % 2 == 0)
                            even++;
                        else
                            odd++;
                    }
                    catch
                    { }
                if (even > odd)
                    message = "чет!";
                else if (even < odd)
                    message = "нечет!";
                else
                    message = "равно!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Отправлено: " + message);
                Thread.Sleep(1000);  // пауза перед следующей отправкой
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                break;
            }
        }
        client.Close();
    }
}

class Program
{
    static void Main()
    {
        Server server = new Server();
        server.Start();
    }
}
