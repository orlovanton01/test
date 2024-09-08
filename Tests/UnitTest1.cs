using FluentAssertions;
using System.Net.Sockets;
using System.Text;

namespace Tests;

public class ServerClientIntegrationTests
{
    private readonly int _port = 8888;
    private readonly string _serverHost = "localhost";

    [Fact]
    public async Task Client_Should_Receive_Data_From_Server()
    {
        // ������ ������������ � ������� � ���������� (�� �����)
        using var client = new TcpClient(_serverHost, _port);
        using var stream = client.GetStream();
        byte[] buffer = new byte[256];

        // ��������� ������ �� �������
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        // ���������, ��� ��������� �� ������� �������� ���������� ��������
        receivedMessage.Should().BeOneOf("���!", "�����!", "�����!");
    }

    [Fact]
    public async Task Server_Should_Handle_Multiple_Clients()
    {
        // ������������ � ������� � ���� ��������
        using var client1 = new TcpClient(_serverHost, _port);
        using var client2 = new TcpClient(_serverHost, _port);

        using var stream1 = client1.GetStream();
        using var stream2 = client2.GetStream();

        byte[] buffer1 = new byte[256];
        byte[] buffer2 = new byte[256];

        // ������ ������ �� ������� ������ ���������
        int bytesRead1 = await stream1.ReadAsync(buffer1, 0, buffer1.Length);
        int bytesRead2 = await stream2.ReadAsync(buffer2, 0, buffer2.Length);

        string receivedMessage1 = Encoding.UTF8.GetString(buffer1, 0, bytesRead1);
        string receivedMessage2 = Encoding.UTF8.GetString(buffer2, 0, bytesRead2);

        // ��� ������� ������ �������� ���������� ��������� �� �������
        receivedMessage1.Should().BeOneOf("���!", "�����!", "�����!");
        receivedMessage2.Should().BeOneOf("���!", "�����!", "�����!");
    }
}