using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Nico.net
{
	class NicoPacketEnDecoder :IPacketDecoder<object, object, object>, IPacketEncoder<object, object, object>
	{
		private static readonly UTF8Encoding encoding = new UTF8Encoding();
		private static readonly XmlSerializerNamespaces EmptyNamespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
		private static readonly XmlWriterSettings EmptySettings = new XmlWriterSettings() { Indent = false, OmitXmlDeclaration = true };
		#region IPacketEncoder<object,object,object> メンバー

		public byte[] Encode(object packet, SocketClient<object, object, object> client)
		{

			XmlSerializer serializer = new XmlSerializer(packet.GetType());
			TextWriter writer = new StringWriter();
			var xml_writer = XmlWriter.Create(writer, EmptySettings);
			serializer.Serialize(xml_writer, packet, EmptyNamespace);
			string xml = writer.ToString();
			return encoding.GetBytes(xml + "\0");
		}

		#endregion

		#region IPacketDecoder<object,object,object> メンバー

		public object Decode(object sender, SocketClient<object, object, object> client, SocketStream<object, object, object> stream)
		{
			MemoryStream ms = new MemoryStream();
			byte data;
			while((data = (byte)stream.ReadByte()) != 0)
			{
				ms.WriteByte(data);
			}

			string xml =  encoding.GetString(ms.ToArray());
			return NicoXmlRegistry.Deserialize(xml);
		}

		#endregion
	}
}
