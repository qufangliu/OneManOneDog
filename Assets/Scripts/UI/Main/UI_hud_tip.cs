/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_hud_tip : GComponent
	{
		public GTextField tip_text;

		public const string URL = "ui://e4ybow8yjk0io";

		public static UI_hud_tip CreateInstance()
		{
			return (UI_hud_tip)UIPackage.CreateObject("Main","hud_tip");
		}

		public UI_hud_tip()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			tip_text = (GTextField)this.GetChildAt(1);
		}
	}
}