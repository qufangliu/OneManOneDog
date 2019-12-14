/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_skill : GComponent
	{
		public GList skill_list;
		public GList accompany_skill_list;
		public GButton start_btn;

		public const string URL = "ui://e4ybow8yjk0ik";

		public static UI_skill CreateInstance()
		{
			return (UI_skill)UIPackage.CreateObject("Main","skill");
		}

		public UI_skill()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			skill_list = (GList)this.GetChildAt(2);
			accompany_skill_list = (GList)this.GetChildAt(5);
			start_btn = (GButton)this.GetChildAt(6);
		}
	}
}