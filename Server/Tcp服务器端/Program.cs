﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Tcp服务器端
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = IPAddress.Parse("192.168.1.31");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 88);
            serverSocket.Bind(ipEndPoint);//绑定ip和端口号
            serverSocket.Listen(0);//开始监听端口号
            Socket clientSocket = serverSocket.Accept();//接收客户端链接
            string msg = "Hello client!你好...";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);

            //接收客户端的一条消息
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msgReceive = System.Text.Encoding.UTF8.GetString(dataBuffer,0,count);
            Console.WriteLine(msgReceive);

            clientSocket.Close();
            serverSocket.Close();
        }
    }
}
