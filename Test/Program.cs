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


			//NicoClient alertClient = NicoClient.ConnectAlertServer();
			//string live = Console.ReadLine();
			//alertClient.Close();

			NicoClient.ConnectLiveCommentServer("", container);
			Console.ReadLine();
		}
	}
}
