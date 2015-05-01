using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CookedCookie;
using Nico.net;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{//http://live.nicovideo.jp/api/getalertinfo


			var container = CookieOven.GetCookie(new Uri("http://nicovideo.jp/"), BrowserType.Chrome);


			/*foreach(Cookie item in container.GetCookies(new Uri("http://nicovideo.jp/")))
			{
				Console.WriteLine(item.Name + " => " + item.Value);

			}*/


			NicoClient.ConnectAlertServer();
			//NicoClient.Connect(new NicoServerInfo() { Address = "hiroba.nicovideo.jp", Port = 2525, ThreadId = 1322481864 },
			//new NicoThread() { ResFrom = -1000, Version = 20061206, NicoruScore = 1, Thread = 1322481864 });
			Console.ReadLine();
		}
	}
}
