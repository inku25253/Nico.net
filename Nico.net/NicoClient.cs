using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets.Plus;
using System.Xml;
using System.Xml.Serialization;

namespace Nico.net
{
	public class NicoClient
	{
		public const string AlertApiUrl = "http://live.nicovideo.jp/api/getalertinfo";

		private static readonly Uri NiconicoUri = new Uri("http://nicovideo.jp/");

		public static NicoClient ConnectAlertServer()
		{
			WebClient client = new WebClient();
			XmlSerializer serializer = new XmlSerializer(typeof(NicoAlertInfo));
			string xml = client.DownloadString(AlertApiUrl);
			Console.WriteLine(xml);
			StringReader sr = new StringReader(xml);
			NicoAlertInfo info = (NicoAlertInfo)serializer.Deserialize(sr);

			return new NicoClient(info.ServerInfo, new NicoThread() { Thread = info.ServerInfo.ThreadId, Version = 20061206 });
		}
		public static NicoClient Connect(NicoServerInfo info, NicoThread thread)
		{
			return new NicoClient(info, thread);
		}



		private SocketClient<object,object,object> client = new SocketClient<object, object, object>();

		private NicoClient(NicoServerInfo serverInfo, NicoThread threadData)
		{
			var packetEnDecoder = new NicoPacketEnDecoder();
			client.Encoder = packetEnDecoder;
			client.Decoder = packetEnDecoder;

			client.OnSocketException += (s, e) => Console.WriteLine(e.Exception.Message);
			client.OnDisconnect += (s, e) => Console.WriteLine("Disconnected.");

			client.OnConnected += (s, e) =>
			{
				Console.WriteLine("Connected");
				e.Send(threadData);
			};

			client.OnDataReceived += client_OnDataReceived;
			client.Connect(new DnsEndPoint(serverInfo.Address, serverInfo.Port));
		}
		private StreamWriter fs = File.CreateText("log");
		void client_OnDataReceived(object sender, SocketReceiveEventArgs<object, object, object> args)
		{
			if(args.Packet is NicoResponse)
			{
				NicoAlertResponse response =(NicoResponse)args.Packet;
				Console.WriteLine("==================================");
				Console.WriteLine("  Live\t\t" + response.LiveId);
				Console.WriteLine("  User\t\t" + response.LiveOwnerUserId);
				Console.WriteLine("  Comunity\t" + response.ComunityId);
				Console.WriteLine("==================================");
				Console.WriteLine();
			}
		}
	}
}
