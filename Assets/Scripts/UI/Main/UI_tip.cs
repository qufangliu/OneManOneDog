/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_tip : GComponent
	{
		public GGraph bg;
		public GTextField content_txt;

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

			bg = (GGraph)this.GetChildAt(0);
			content_txt = (GTextField)this.GetChildAt(1);
		}
	}
}