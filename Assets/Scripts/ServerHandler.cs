using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class ServerHandler : MonoBehaviour
{
    public static ServerHandler inst;

    NetworkStream networkStream;
    TcpClient tcpClient;

    byte[] recieveBuffer;

    void Awake()
    {
        inst = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Connect(string ip, int port)
    {
        tcpClient = new TcpClient
        {
            ReceiveBufferSize = 4096,
            SendBufferSize = 4096
        };

        recieveBuffer = new byte[4096];

        tcpClient.BeginConnect(IPAddress.Parse(ip), port, OnConnectCallback, tcpClient);
    }

    void OnConnectCallback(IAsyncResult result)
    {
        tcpClient.EndConnect(result);

        if (!tcpClient.Connected)
            return;

        print("Connected!");

        networkStream = tcpClient.GetStream();

        networkStream.BeginRead(recieveBuffer, 0, 4096, OnRecieveCallback, null);
    }

    void OnRecieveCallback(IAsyncResult result)
    {
        int dataLength = networkStream.EndRead(result);

        if (dataLength < 0)
            return;

        byte[] data = new byte[dataLength];
        Array.Copy(recieveBuffer, data, dataLength);

        networkStream.BeginRead(recieveBuffer, 0, 4096, OnRecieveCallback, null);

        CommandsHandler.inst.HandleCommand(Encoding.Unicode.GetString(data));
    }

    public void SendCommand(string command)
    {
        byte[] message = Encoding.Unicode.GetBytes(command);
        networkStream.Write(message, 0, message.Length);
    }

}
