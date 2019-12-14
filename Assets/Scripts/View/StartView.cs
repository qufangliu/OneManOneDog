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
            Debug.Log( $"登录游戏界面" );
            
            ui.start_btn.onClick.Set( () =>
            {
                UIHelper.OpenView<SelectRoleView>( typeof(UI_role) );
                Close();
            } );
        }
    }
}