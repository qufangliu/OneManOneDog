/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_role_bar : GComponent
	{
		public Controller state;
		public GLoader man_loader;
		public GLoader dog_loader;
		public GButton select_btn;

		public const string URL = "ui://e4ybow8yjk0ig";

		public static UI_role_bar CreateInstance()
		{
			return (UI_role_bar)UIPackage.CreateObject("Main","role_bar");
		}

		public UI_role_bar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			state = this.GetControllerAt(0);
			man_loader = (GLoader)this.GetChildAt(0);
			dog_loader = (GLoader)this.GetChildAt(1);
			select_btn = (GButton)this.GetChildAt(2);
		}
	}
}