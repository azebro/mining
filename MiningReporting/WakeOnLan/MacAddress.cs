using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WakeOnLan
{
    public class MacAddress
    {
        /// <summary>
        /// Test a MACAddress byte Array.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static bool Test(byte[] macAddress)
        {
            if (macAddress == null) return false;
            return macAddress.Length == 6;
        }

        /// <summary>
        /// Test a MACAddress string.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static bool Test(string macAddress)
        {
            const string validChars = "0123456789ABCDEFabcdef";

            if (string.IsNullOrEmpty(macAddress)) return false;
            if (macAddress.Length != 12) return false;

            return macAddress.All(c => validChars.IndexOf(c) >= 0);
        }

        /// <summary>
        /// Parse a MACAddress string into a byte array.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static byte[] Parse(string macAddress)
        {
            var mac = new byte[6];

            if (!Test(macAddress))
                throw new ArgumentException(
                    "Invalid MACAddress string.",
                    "macAddress",
                    null);

            for (var i = 0; i < 6; i++)
            {
                var t = macAddress.Substring((i*2), 2);
                mac[i] = Convert.ToByte(t, 16);
            }

            return mac;
        }

        /// <summary>
        /// Attempt to parse a MACAddress string
        ///   without throwing an Exception.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        public static bool TryParse(string macAddress, out byte[] Address)
        {
            try
            {
                Address = Parse(macAddress);
                return true;
            }
            catch
            {
                Address = null;
                return false;
            }
        }

        /// <summary>
        /// Convert a byte array MACAddress to a string.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static string ToString(byte[] macAddress)
        {
            if (!Test(macAddress))
                throw new ArgumentException(
                    "Invalid MACAddress byte array.",
                    "macAddress",
                    null);

            return BitConverter.ToString(macAddress).Replace("-", "");
        }


        /// <summary>
        /// Sends a Wake-On-LAN 'magic' packet to
        ///   the specified MACAddress string.
        /// </summary>
        /// <param name="macAddress"></param>
        public static void SendWolPacket(string macAddress)
        {

            if (!Test(macAddress))
                throw new ArgumentException(
                    "Invalid MACAddress string.",
                    "macAddress",
                    null);

            byte[] mac = Parse(macAddress);

            SendWolPacket(mac);
        }

        /// <summary>
        /// Sends a Wake-On-LAN 'magic' packet to
        ///   the specified MACAddress byte array.
        /// </summary>
        /// <param name="macAddress"></param>
        public static void SendWolPacket(byte[] macAddress)
        {

            if (!Test(macAddress))
                throw new ArgumentException(
                    "Invalid MACAddress byte array.",
                    "macAddress",
                    null);

            // WOL 'magic' packet is sent over UDP.
            using (var client = new UdpClient())
            {

                // Send to: 255.255.255.0:40000 over UDP.
                client.Connect(IPAddress.Broadcast, 40000);

                // Two parts to a 'magic' packet:
                //     First is 0xFFFFFFFFFFFF,
                //     Second is 16 * MACAddress.
                var packet = new byte[17*6];

                // Set to: 0xFFFFFFFFFFFF.
                for (var i = 0; i < 6; i++)
                {
                    packet[i] = 0xFF;
                }

                // Set to: 16 * MACAddress
                for (var i = 1; i <= 16; i++)
                {
                    for (var j = 0; j < 6; j++)
                    {
                        packet[i*6 + j] = macAddress[j];
                    }
                }

                // Send WOL 'magic' packet.
                client.Send(packet, packet.Length);
            }
        }

    }
}



