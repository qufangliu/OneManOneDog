/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_role : GComponent
	{
		public GGraph bg;
		public UI_role_bar role_1;
		public UI_role_bar role_2;
		public GImage line;

		public const string URL = "ui://e4ybow8yjk0if";

		public static UI_role CreateInstance()
		{
			return (UI_role)UIPackage.CreateObject("Main","role");
		}

		public UI_role()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GGraph)this.GetChildAt(0);
			role_1 = (UI_role_bar)this.GetChildAt(1);
			role_2 = (UI_role_bar)this.GetChildAt(2);
			line = (GImage)this.GetChildAt(3);
		}
	}
}