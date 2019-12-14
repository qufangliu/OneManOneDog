using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class StartView : ViewBase
    {
        private UI_start ui => (UI_start)uiComponent;
        public override void OnOpen( object data )
        {
            ui.start_btn.onClick.Set( () =>
            {
                UIHelper.OpenView<TipView>( typeof(UI_tip), "第一天..." );
            } );
        }
    }
}