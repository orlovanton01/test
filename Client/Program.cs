
using System.Net.Sockets;
using System.Text;

class Client
{
    private TcpClient client;
    private NetworkStream stream;

    public Client()
    {
        client = new TcpClient("127.0.0.1", 8888);
        stream = client.GetStream();
    }

    public void Start()
    {
        Thread receivingThread = new Thread(ReceiveData);
        receivingThread.Start();
    }

    private void ReceiveData()
    {
        byte[] buffer = new byte[256];
        while (true)
        {
            try
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    Console.WriteLine("Соединение с сервером потеряно");
                    break;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
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
        Client client = new Client();
        client.Start();
        Console.ReadLine(); // ожидание завершения работы клиента
    }
}
