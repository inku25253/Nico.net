using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace Nico.net
{
	[Serializable()]
	public struct NicoServerInfo
	{
		[XmlElement("addr")]
		[DeserializeAs(Attribute = false, Name = "addr")]
		public string Address { get; set; }

		[XmlElement("port")]
		[DeserializeAs(Attribute = false, Name = "port")]
		public int Port { get; set; }

		[XmlElement("thread")]
		[DeserializeAs(Attribute = false, Name = "thread")]
		public long ThreadId { get; set; }
	}

	public class NicoStream
	{

		public class NicoPress
		{
			[XmlElement("display_lines")]
			public int DisplayLines { get; set; }
			[XmlElement("display_time")]
			public int DisplayTime { get; set; }

			/// <summary>
			/// 不明
			/// </summary>
			[XmlElement("style_conf")]
			public string StyleConf { get; set; }
		}

		[XmlRoot("contents")]
		[DeserializeAs(Name = "contents")]
		public class NicoContents
		{
			[XmlAttribute("id")]
			[DeserializeAs(Attribute = false, Name = "id")]
			public string Id { get; set; }

			[XmlAttribute("disableAudio")]
			[DeserializeAs(Attribute = false, Name = "disableAudio")]
			public bool DisableAudio { get; set; }

			[XmlAttribute("disableVideo")]
			[DeserializeAs(Attribute = false, Name = "disableVideo")]
			public bool DisableVideo { get; set; }

			[XmlAttribute("start_time")]
			[DeserializeAs(Attribute = false, Name = "start_time")]
			public long StartTime { get; set; }

			[XmlText]
			[DeserializeAs()]
			public string Content { get; set; }
		}

		[XmlElement("id")]
		[DeserializeAs(Name = "id")]
		public string LiveId { get; set; }

		[XmlElement("title")]
		[DeserializeAs(Name = "title")]
		public string LiveTitle { get; set; }

		[XmlElement("description")]
		[DeserializeAs(Name = "description")]
		public string LiveDescription { get; set; }

		[XmlElement("provider_type")]
		[DeserializeAs(Name = "provider_type")]
		public string ProviderType { get; set; }

		[XmlElement("default_community")]
		[DeserializeAs(Name = "default_community")]
		public string Community { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("international")]
		[DeserializeAs(Name = "international")]
		public int International { get; set; }

		[XmlElement("is_owner")]
		[DeserializeAs(Name = "is_owner")]
		public bool IsOwner { get; set; }

		[XmlElement("owner_id")]
		[DeserializeAs(Name = "owner_id")]
		public long OwnerId { get; set; }

		[XmlElement("owner_name")]
		[DeserializeAs(Name = "owner_name")]
		public string OwnerName { get; set; }

		/// <summary>
		/// 不明(多分bool)
		/// </summary>
		[XmlElement("is_reserved")]
		[DeserializeAs(Name = "is_reserved")]
		public bool IsReserved { get; set; }

		/// <summary>
		/// 多分bool
		/// </summary>
		[XmlElement("is_niconico_enquete_enable")]
		[DeserializeAs(Name = "is_niconico_enquete_enable")]
		public bool IsNiconicoEnqueteEnable { get; set; }

		[XmlElement("watch_count")]
		[DeserializeAs(Name = "watch_count")]
		public int WathCount { get; set; }

		[XmlElement("comment_count")]
		[DeserializeAs(Name = "comment_count")]
		public int CommentCount { get; set; }

		[XmlElement("base_time")]
		[DeserializeAs(Name = "base_time")]
		public long BaseTime { get; set; }

		[XmlElement("open_time")]
		[DeserializeAs(Name = "open_time")]
		public long OpenTime { get; set; }

		[XmlElement("start_time")]
		[DeserializeAs(Name = "start_time")]
		public long StartTime { get; set; }

		[XmlElement("end_time")]
		[DeserializeAs(Name = "end_time")]
		public long EndTime { get; set; }

		/// <summary>
		/// 不明(多分int)
		/// </summary>
		[XmlElement("is_rerun_stream")]
		[DeserializeAs(Name = "is_rerun_stream")]
		public int IsRerunStream { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("bournbon_url")]
		[DeserializeAs(Name = "bournbon_url")]
		public string BournbonUrl { get; set; }

		[XmlElement("full_video")]
		[DeserializeAs(Name = "full_video")]
		public string FullVideo { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("after_video")]
		[DeserializeAs(Name = "after_video")]
		public string AfterVideo { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("before_video")]
		[DeserializeAs(Name = "before_video")]
		public string BeforeVideo { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("kickout_video")]
		[DeserializeAs(Name = "kickout_video")]
		public string KickoutVideo { get; set; }

		[XmlElement("twitter_tag")]
		[DeserializeAs(Name = "twitter_tag")]
		public string TwitterTag { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("danjo_comment_mode")]
		[DeserializeAs(Name = "danjo_comment_mode")]
		public int DanjoCommentMode { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("infinity_mode")]
		[DeserializeAs(Name = "infinity_mode")]
		public int InfinityMode { get; set; }

		[XmlElement("archive")]
		[DeserializeAs(Name = "archive")]
		public int Archive { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("press")]
		[DeserializeAs(Name = "press")]
		public NicoPress Press { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("plugin_delay")]
		[DeserializeAs(Name = "plugin_delay")]
		public string PluginDelay { get; set; }

		[XmlElement("plugin_url")]
		[DeserializeAs(Name = "plugin_url")]
		public string PluginUrl { get; set; }

		[XmlElement("plugin_urls")]
		[DeserializeAs(Name = "plugin_urls")]
		public List<string> PluginUrls { get; set; }

		[XmlElement("allow_netduetto")]
		[DeserializeAs(Name = "allow_netduetto")]
		public bool AllowNetduetto { get; set; }

		/// <summary>
		/// 不明　NGデータ系？
		/// </summary>
		[XmlElement("nd_token")]
		[DeserializeAs(Name = "nd_token")]
		public string NdToken { get; set; }

		[XmlElement("ng_scoring")]
		[DeserializeAs(Name = "ng_scoring")]
		public bool NgScoring { get; set; }

		[XmlElement("is_nonarchive_timeshift_enable")]
		[DeserializeAs(Name = "is_nonarchive_timeshift_enable")]
		public bool IsTimeshiftEnable { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("is_timeshift_reserved")]
		[DeserializeAs(Name = "is_timeshift_reserved")]
		public bool IsTimeshiftReserved { get; set; }

		[XmlElement("header_comment")]
		[DeserializeAs(Name = "header_comment")]
		public bool HeaderComment { get; set; }

		[XmlElement("footer_comment")]
		[DeserializeAs(Name = "footer_comment")]
		public bool FooterComment { get; set; }

		[XmlElement("split_bottom")]
		[DeserializeAs(Name = "split_bottom")]
		public bool SplitBottom { get; set; }

		[XmlElement("split_top")]
		[DeserializeAs(Name = "split_top")]
		public bool SplitTop { get; set; }

		[XmlElement("background_comment")]
		[DeserializeAs(Name = "background_comment")]
		public bool BackgroundComment { get; set; }

		[XmlElement("font_scale")]
		[DeserializeAs(Name = "font_scale")]
		public string FontScale { get; set; }

		[XmlElement("comment_lock")]
		[DeserializeAs(Name = "comment_lock")]
		public bool CommentLock { get; set; }

		[XmlElement("telop/enable")]
		[DeserializeAs(Name = "telop/enable")]
		public bool IsTelopEnable { get; set; }

		[XmlElement("contents_list")]
		[DeserializeAs(Name = "contents_list")]
		public List<NicoContents> ContentsList { get; set; }

		[XmlElement("picture_url")]
		[DeserializeAs(Name = "picture_url")]
		public string PictureUrl { get; set; }

		[XmlElement("thumb_url")]
		[DeserializeAs(Name = "thumb_url")]
		public string ThumbUrl { get; set; }

		/// <summary>
		/// 不明
		/// </summary>
		[XmlElement("is_priority_prefecturs")]
		[DeserializeAs(Name = "is_priority_prefecturs")]
		public bool IsPriorityPrefecture { get; set; }

	}
	public class NicoUser
	{

		[XmlElement("user_id")]
		[DeserializeAs(Name = "user_id")]
		public long UserId { get; set; }

		[XmlElement("nickname")]
		[DeserializeAs(Name = "nickname")]
		public string Nickname { get; set; }

		[XmlElement("is_premium")]
		[DeserializeAs(Name = "is_premium")]
		public bool isPremium { get; set; }

		[XmlElement("userAge")]
		[DeserializeAs(Name = "userAge")]
		public int UserAge { get; set; }

		[XmlElement("userSex")]
		[DeserializeAs(Name = "userSex")]
		public int UserSex { get; set; }

		[XmlElement("userDomain")]
		[DeserializeAs(Name = "userDomain")]
		public string UserCalture { get; set; }

		[XmlElement("userPrefecture")]
		[DeserializeAs(Name = "userPrefecture")]
		public int UserPrefecture { get; set; }

		[XmlElement("userLanguage")]
		[DeserializeAs(Name = "userLanguage")]
		public string UserLanguage { get; set; }

		[XmlElement("room_label")]
		[DeserializeAs(Name = "room_label")]
		public string RoomLabel { get; set; }

		[XmlElement("room_seetno")]
		[DeserializeAs(Name = "room_seetno")]
		public int RoomSeetNo { get; set; }

		[XmlElement("is_join")]
		[DeserializeAs(Name = "is_join")]
		public string isJoin { get; set; }

		[XmlElement("twitter_info")]
		[DeserializeAs(Name = "twitter_info")]
		public NicoTwitterInfo TwitterInfo { get; set; }
	}
	public class NicoTwitterInfo
	{
		[XmlElement("status")]
		[DeserializeAs(Name = "status")]
		public string Status { get; set; }

		[XmlElement("screen_name")]
		[DeserializeAs(Name = "screen_name")]
		public string ScreenName { get; set; }

		[XmlElement("followers_count")]
		[DeserializeAs(Name = "followers_count")]
		public int FollowerCount { get; set; }

		[XmlElement("is_vip")]
		[DeserializeAs(Name = "is_vip")]
		public bool IsVip { get; set; }

		[XmlElement("profile_image_url")]
		[DeserializeAs(Name = "profile_image_url")]
		public string ProfileImage { get; set; }

		[XmlElement("after_auth")]
		[DeserializeAs(Name = "after_auth")]
		public bool AfterAuth { get; set; }

		[XmlElement("tweet_token")]
		[DeserializeAs(Name = "tweet_token")]
		public string TweetToken { get; set; }
	}


	[XmlRoot("getalertstatus")]
	public struct NicoAlertInfo
	{
		[XmlAttribute("status")]
		[DeserializeAs(Attribute = true, Name = "status")]
		public string Status { get; set; }
		[XmlAttribute("time")]
		[DeserializeAs(Attribute = true, Name = "time")]
		public long Timestamp { get; set; }
		[XmlElement("user_id")]
		[DeserializeAs(Attribute = false, Name = "user_id")]
		public string UserId { get; set; }
		[XmlElement("user_hash")]
		[DeserializeAs(Attribute = false, Name = "user_hash")]
		public string UserHash { get; set; }
		[XmlElement("ms")]
		[DeserializeAs(Attribute = false, Name = "ms")]
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





	[XmlRoot("thread")]
	public class NicoThread
	{

		public NicoThread()
		{
			Version = 20061206;
		}

		public NicoThread(NicoServerInfo info)
			: this()
		{
			this.Thread = info.ThreadId;
		}

		[XmlAttribute("version")]
		public long Version { get; set; }
		[XmlAttribute("thread")]
		public long Thread { get; set; }
		[XmlAttribute("res_from"), DefaultValue(0)]
		public long ResFrom { get; set; }
		[XmlAttribute("fork"), DefaultValue(false)]
		public bool Fork { get; set; }
		[XmlAttribute("scores"), DefaultValue(false)]
		public bool ScoreRequest { get; set; }
		[XmlAttribute("click_revision"), DefaultValue(0)]
		public int AtButtonClickCount { get; set; }
		[XmlAttribute("user_id"), DefaultValue("")]
		public string UserId { get; set; }

		[XmlAttribute("nicoru"), DefaultValue(0)]
		public int NicoruScore { get; set; }
		[XmlAttribute("when"), DefaultValue(0)]
		public long When { get; set; }
		[XmlAttribute("waybackkey"), DefaultValue("")]
		public string WayBackKey { get; set; }
		[XmlAttribute("threadkey"), DefaultValue("")]
		public string ThreadKey { get; set; }
		[XmlAttribute("with_global"), DefaultValue(0)]
		public int WithGlobal { get; set; }
		[XmlAttribute("language"), DefaultValue(0)]
		public int Language { get; set; }
	}

	[XmlRoot("getplayerstatus")]
	[DeserializeAs(Name = "getplayerstatus")]
	public class NicoPlayerStatus
	{
		[XmlAttribute("status")]
		[DeserializeAs(Name = "status", Attribute = true)]
		public string Status { get; set; }

		[XmlAttribute("time")]
		[DeserializeAs(Name = "time", Attribute = true)]
		public long Time { get; set; }

		[XmlElement("stream")]
		[DeserializeAs(Name = "stream")]
		public NicoStream Stream { get; set; }

		[XmlElement("user")]
		[DeserializeAs(Name = "user")]
		public NicoUser User { get; set; }

		//TODO: つかれた。
		public dynamic Rtmp { get; set; }
		public dynamic Player { get; set; }
		public dynamic Marquee { get; set; }
		public dynamic Twitter { get; set; }
		//public NicoRtmp Rtmp { get; set; }
		[XmlElement("ms")]
		[DeserializeAs(Name = "ms")]
		public NicoServerInfo CommentServer { get; set; }
	}
}