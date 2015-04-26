using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading.Tasks;

namespace Nico.net
{
	class NicoPacketEnDecoder :IPacketDecoder<object, NicoPacket, NicoPacket>, IPacketEncoder<object, NicoPacket, NicoPacket>
	{
		private static readonly UTF8Encoding encoding = new UTF8Encoding();

		#region IPacketEncoder<object,NicoPacket,NicoPacket> メンバー

		public byte[] Encode(NicoPacket packet, SocketClient<object, NicoPacket, NicoPacket> client)
		{
			return encoding.GetBytes(packet.xmlData + "\0");
		}

		#endregion

		#region IPacketDecoder<object,NicoPacket,NicoPacket> メンバー

		public NicoPacket Decode(object sender, SocketClient<object, NicoPacket, NicoPacket> client, SocketStream<object, NicoPacket, NicoPacket> stream)
		{
			MemoryStream ms = new MemoryStream();
			byte data;
			while((data = (byte)stream.ReadByte()) != 0)
			{
				ms.WriteByte(data);
			}

			NicoPacket packet = new NicoPacket();
			packet.xmlData = encoding.GetString(ms.ToArray());
			return packet;
		}

		#endregion
	}
}
