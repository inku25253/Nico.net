using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nico.net
{
	public struct NicoServerInfo
	{
		[XmlElement("addr")]
		public string Address { get; set; }
		[XmlElement("port")]
		public int Port { get; set; }
		[XmlElement("thread")]
		public long ThreadId { get; set; }
	}
	[XmlRoot("getalertstatus")]
	public struct NicoAlertInfo
	{
		[XmlAttribute("status")]
		public string Status { get; set; }
		[XmlAttribute("time")]
		public long Timestamp { get; set; }
		[XmlElement("user_id")]
		public string UserId { get; set; }
		[XmlElement("user_hash")]
		public string UserHash { get; set; }
		[XmlElement("ms")]
		public NicoServerInfo ServerInfo { get; set; }

	}
	[XmlRoot("chat")]
	public struct NicoResponse
	{
		[XmlAttribute("thread")]
		public long ThreadId { get; set; }
		[XmlAttribute("no")]
		public long No { get; set; }
		[XmlAttribute("date")]
		public long Timestamp { get; set; }
		[XmlAttribute("date_usec")]
		public long Time_Usec { get; set; }
		[XmlAttribute("mail")]
		public string Mail { get; set; }
		[XmlAttribute("user_id")]
		public string UserId { get; set; }
		[XmlAttribute("anonymity")]
		public string Anonymity { get; set; }
		[XmlAttribute("premium")]
		public int PremiumFlag { get; set; }
		[XmlAttribute("leaf")]
		public long Leaf { get; set; }
		[XmlAttribute("scores")]
		public int NgScore { get; set; }
		[XmlAttribute("nicoru")]
		public int NicoruScore { get; set; }
		[XmlAttribute("yourpost")]
		public string YourPost { get; set; }
		[XmlText]
		public string Content { get; set; }
	}

	public struct NicoAlertResponse
	{
		private NicoResponse response;
		private string[] liveDatas;

		public string LiveId { get { return "lv" + liveDatas[0]; } }
		public string ComunityId { get { return liveDatas[1]; } }
		public string LiveOwnerUserId { get { return liveDatas[2]; } }
		private NicoAlertResponse(NicoResponse response)
		{
			this.response = response;
			liveDatas = response.Content.Split(',');
		}

		public static implicit operator NicoAlertResponse(NicoResponse x)
		{
			return new NicoAlertResponse(x);
		}
	}
}
