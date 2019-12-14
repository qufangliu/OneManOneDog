/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ui.Main
{
	public partial class UI_result : GComponent
	{
		public Controller state;
		public GTextField title_txt;
		public GTextField bug_num_txt;
		public GTextField require_num_txt;
		public GLoader man_loader;
		public GProgressBar man_progress_bar;
		public GLoader dog_loader;
		public GProgressBar dog_progress_bar;
		public GTextField gain_txt;

		public const string URL = "ui://e4ybow8yjk0iq";

		public static UI_result CreateInstance()
		{
			return (UI_result)UIPackage.CreateObject("Main","result");
		}

		public UI_result()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			state = this.GetControllerAt(0);
			title_txt = (GTextField)this.GetChildAt(1);
			bug_num_txt = (GTextField)this.GetChildAt(5);
			require_num_txt = (GTextField)this.GetChildAt(10);
			man_loader = (GLoader)this.GetChildAt(13);
			man_progress_bar = (GProgressBar)this.GetChildAt(14);
			dog_loader = (GLoader)this.GetChildAt(15);
			dog_progress_bar = (GProgressBar)this.GetChildAt(16);
			gain_txt = (GTextField)this.GetChildAt(18);
		}
	}
}