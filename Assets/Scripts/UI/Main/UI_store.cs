/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_store : GComponent
	{
		public GComponent goods_list;

		public const string URL = "ui://e4ybow8yjk0it";

		public static UI_store CreateInstance()
		{
			return (UI_store)UIPackage.CreateObject("Main","store");
		}

		public UI_store()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			goods_list = (GComponent)this.GetChildAt(1);
		}
	}
}