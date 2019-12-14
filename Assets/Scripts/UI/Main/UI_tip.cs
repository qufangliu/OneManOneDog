/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_tip : GComponent
	{
		public Controller content;
		public GTextField content_txt;
		public GButton skip_btn;

		public const string URL = "ui://e4ybow8ykvhj1";

		public static UI_tip CreateInstance()
		{
			return (UI_tip)UIPackage.CreateObject("Main","tip");
		}

		public UI_tip()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			content = this.GetControllerAt(0);
			content_txt = (GTextField)this.GetChildAt(0);
			skip_btn = (GButton)this.GetChildAt(1);
		}
	}
}