using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets.Plus;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Nico.net
{
	public class NicoClient
	{
		public const string AlertApiUrl = "http://live.nicovideo.jp/api/getalertinfo";

		public static NicoClient ConnectAlertServer()
		{
			WebClient client = new WebClient();

			XmlSerializer serializer = new XmlSerializer(typeof(NicoAlertInfo));
			NicoAlertInfo info = (NicoAlertInfo)serializer.Deserialize(client.OpenRead(AlertApiUrl));

			return new NicoClient(info.ServerInfo);
		}



		private SocketClient<object,NicoPacket,NicoPacket> client = new SocketClient<object, NicoPacket, NicoPacket>();

		private NicoClient(NicoServerInfo serverInfo)
		{
			var packetEnDecoder = new NicoPacketEnDecoder();
			client.Encoder = packetEnDecoder;
			client.Decoder = packetEnDecoder;


			client.OnConnected += (s, e) =>
			{
				e.Send(new NicoPacket() { xmlData = "<thread thread=\"" + serverInfo.ThreadId + "\" version=\"20061206\" res_from=\"0\" scores=\"1\"/>" });
			};

			client.OnDataReceived += client_OnDataReceived;
			client.Connect(new DnsEndPoint(serverInfo.Address, serverInfo.Port));
		}
		private StreamWriter fs = File.CreateText("log");
		XmlSerializer serializer = new XmlSerializer(typeof(NicoResponse));
		void client_OnDataReceived(object sender, SocketReceiveEventArgs<object, NicoPacket, NicoPacket> args)
		{
			if(args.Packet.xmlData.StartsWith("<chat"))
			{
				NicoAlertResponse response = (NicoResponse)serializer.Deserialize(XmlReader.Create(new StringReader(args.Packet.xmlData)));
				Console.WriteLine(response.LiveId + "\n\t" + response.LiveOwnerUserId + "\n\t" + response.ComunityId);
			}
		}
	}
}
