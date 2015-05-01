using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets.Plus;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using RestSharp;

namespace Nico.net
{
	public class NicoClient
	{
		public const string AlertApiUrl = "http://live.nicovideo.jp/api/getalertinfo";
		public const string PlayerStatusUrl ="http://live.nicovideo.jp/api/getplayerstatus/";
		private static readonly Regex liveIdRegex = new Regex("lv(<liveId>[0-9]+)");
		private static readonly Uri NiconicoUri = new Uri("http://nicovideo.jp/");

		public static NicoClient ConnectAlertServer()
		{
			RestClient client = new RestClient(AlertApiUrl);
			RestRequest request = new RestRequest();

			request.AddHeader("Accept", "text/html */*");
			var response =  client.ExecuteAsGet<NicoAlertInfo>(request, "GET");
			var info = response.Data;
			return Connect(info.ServerInfo, new NicoThread() { Thread = info.ServerInfo.ThreadId, Version = 20061206 });
		}

		/// <summary>
		/// 未確認
		/// </summary>
		/// <param name="liveId"></param>
		/// <param name="container"></param>
		/// <returns></returns>
		public static NicoClient ConnectLiveCommentServer(string liveId, CookieContainer container)
		{
			var match = liveIdRegex.Match(liveId);
			if(match.Success)
			{
				liveId = match.Groups["liveId"].Value;
			}


			string session = container.GetCookies(NiconicoUri)["user_session"].Value;

			RestClient client = new RestClient(PlayerStatusUrl);
			RestRequest request = new RestRequest(liveId, Method.GET);
			request.AddCookie("user_session", session);
			request.AddHeader("Accept", "text/html */*");


			var result = client.Execute(request);


			XmlSerializer serializer = new XmlSerializer(typeof(NicoPlayerStatus));
			var playerstatus = (NicoPlayerStatus)serializer.Deserialize(new StringReader(result.Content));


			return Connect(playerstatus.CommentServer, new NicoThread() { Thread = playerstatus.CommentServer.ThreadId, Version = 20061206, ResFrom = -playerstatus.Stream.CommentCount });

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


		public void Close()
		{
			client.Close();
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
