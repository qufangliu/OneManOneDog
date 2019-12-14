using UI;
using ui.Main;

namespace View
{
    public class TipView : ViewBase
    {
        private UI_tip ui => (UI_tip)uiComponent;
        
        public override void OnOpen( object data )
        {
            // 内容
            ui.content_txt.text = (string)data;
        }
    }
}