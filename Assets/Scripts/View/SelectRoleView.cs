using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class SelectRoleView : ViewBase
    {
        private UI_role ui => (UI_role)uiComponent;
        
        public override void OnOpen( object data )
        {
            ui.role_1.select_btn.onClick.Set( () =>
            {
                Debug.Log( $"你再选选？" );
            } );
            
            ui.role_2.select_btn.onClick.Set( () =>
            {
                UIHelper.OpenView<SetNameView>( typeof(UI_name) );
                Close();
            } );
        }
    }
}