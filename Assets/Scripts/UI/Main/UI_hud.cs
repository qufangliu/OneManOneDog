/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_hud : GComponent
	{
		public Controller state;
		public UI_hud_tip hud_tip;
		public GProgressBar health_bar;
		public GLoader man_loader;
		public GProgressBar dog_health_bar;
		public GLoader dog_loader;

		public const string URL = "ui://e4ybow8yjk0in";

		public static UI_hud CreateInstance()
		{
			return (UI_hud)UIPackage.CreateObject("Main","hud");
		}

		public UI_hud()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			state = this.GetControllerAt(0);
			hud_tip = (UI_hud_tip)this.GetChildAt(0);
			health_bar = (GProgressBar)this.GetChildAt(1);
			man_loader = (GLoader)this.GetChildAt(2);
			dog_health_bar = (GProgressBar)this.GetChildAt(3);
			dog_loader = (GLoader)this.GetChildAt(4);
		}
	}
}