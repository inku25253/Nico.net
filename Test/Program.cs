using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Nico.net;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{//http://live.nicovideo.jp/api/getalertinfo

			NicoClient.ConnectAlertServer();
			Console.ReadLine();
		}
	}
}
