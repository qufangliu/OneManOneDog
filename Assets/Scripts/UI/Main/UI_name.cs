/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_name : GComponent
	{
		public GLoader dog_loader;
		public GTextInput name_txt;
		public GButton confirm_btn;

		public const string URL = "ui://e4ybow8yjk0ij";

		public static UI_name CreateInstance()
		{
			return (UI_name)UIPackage.CreateObject("Main","name");
		}

		public UI_name()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			dog_loader = (GLoader)this.GetChildAt(0);
			name_txt = (GTextInput)this.GetChildAt(2);
			confirm_btn = (GButton)this.GetChildAt(3);
		}
	}
}