using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using DataAccess;

namespace Collector
{
    public class CGMinerAcceess
    {
        private const string QueryTemplate = "{\"command\":\"summary\"}";

        internal CGMinerSummary.Rootobject QueryCGMiner(string ipAddressString, int port, int rig)
        {
            var theMessageToReceive = new StringBuilder();
            CGMinerSummary.Rootobject summary;
            var ipAddress = IPAddress.Parse(ipAddressString);
            using (var socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                var endpoint = new IPEndPoint(ipAddress, port);
                socket.Connect(endpoint);
                var commandBytes = Encoding.ASCII.GetBytes(QueryTemplate);
                var bytesSent = socket.Send(commandBytes);
                if (!socket.Poll(10000, SelectMode.SelectRead)) return null;
                var bytesToReceive = new byte[1024];
                while (socket.Available > 0)
                {

                    var bytesReceived = socket.Receive(bytesToReceive);
                    theMessageToReceive.Append(Encoding.ASCII.GetString(bytesToReceive, 0, bytesReceived));
                }
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();


            }
            var serlializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof (CGMinerSummary.Rootobject));
            using (var memoryBytes = new MemoryStream(Encoding.ASCII.GetBytes(theMessageToReceive.ToString())))
            {
                summary =
                    (CGMinerSummary.Rootobject)
                        serlializer.ReadObject(memoryBytes);
            }

            
            return summary;
            
            
        }


    }
}
