/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_store_item : GComponent
	{
		public GLoader icon_loader;
		public GTextField name_txt;
		public GTextField price_txt;

		public const string URL = "ui://e4ybow8yjk0is";

		public static UI_store_item CreateInstance()
		{
			return (UI_store_item)UIPackage.CreateObject("Main","store_item");
		}

		public UI_store_item()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			icon_loader = (GLoader)this.GetChildAt(1);
			name_txt = (GTextField)this.GetChildAt(2);
			price_txt = (GTextField)this.GetChildAt(3);
		}
	}
}