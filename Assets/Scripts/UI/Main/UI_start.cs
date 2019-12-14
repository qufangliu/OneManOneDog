/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_start : GComponent
	{
		public GComponent bg;
		public GTextField title_txt;
		public GButton start_btn;

		public const string URL = "ui://e4ybow8yuwco0";

		public static UI_start CreateInstance()
		{
			return (UI_start)UIPackage.CreateObject("Main","start");
		}

		public UI_start()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GComponent)this.GetChildAt(0);
			title_txt = (GTextField)this.GetChildAt(1);
			start_btn = (GButton)this.GetChildAt(3);
		}
	}
}