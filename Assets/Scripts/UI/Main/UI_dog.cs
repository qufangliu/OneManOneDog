/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_dog : GComponent
	{
		public GTextField title_txt;
		public GLoader dog_loader;
		public GButton act_1_btn;
		public GButton act_2_btn;
		public GButton act_3_btn;

		public const string URL = "ui://e4ybow8yjk0iu";

		public static UI_dog CreateInstance()
		{
			return (UI_dog)UIPackage.CreateObject("Main","dog");
		}

		public UI_dog()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			title_txt = (GTextField)this.GetChildAt(0);
			dog_loader = (GLoader)this.GetChildAt(1);
			act_1_btn = (GButton)this.GetChildAt(2);
			act_2_btn = (GButton)this.GetChildAt(3);
			act_3_btn = (GButton)this.GetChildAt(4);
		}
	}
}