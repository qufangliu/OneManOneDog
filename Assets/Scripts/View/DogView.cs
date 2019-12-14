using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class DogView : ViewBase
    {
        private UI_dog ui => (UI_dog)uiComponent;

        public override void OnOpen( object data )
        {
            ui.act_1_btn.onClick.Set( () =>
            {
                Debug.Log( $"抱狗" );
                ui.act_1_btn.enabled = false;
            } );
            
            ui.act_2_btn.onClick.Set( () =>
            {
                Debug.Log( $"撸狗" );
                ui.act_2_btn.enabled = false;
            } );
            
            ui.act_3_btn.onClick.Set( () =>
            {
                Debug.Log( $"去溜狗" );
                ui.act_3_btn.enabled = false;
                UIHelper.OpenView<BattleView>( typeof(UI_hud) );
                Close();
            } );
        }
    }
}