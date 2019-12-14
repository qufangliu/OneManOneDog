/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_skill_item : GComponent
	{
		public Controller state;
		public GLoader icon_loader;

		public const string URL = "ui://e4ybow8yjk0il";

		public static UI_skill_item CreateInstance()
		{
			return (UI_skill_item)UIPackage.CreateObject("Main","skill_item");
		}

		public UI_skill_item()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			state = this.GetControllerAt(0);
			icon_loader = (GLoader)this.GetChildAt(1);
		}
	}
}