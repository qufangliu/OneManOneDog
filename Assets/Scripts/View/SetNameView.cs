using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class SetNameView : ViewBase
    {
        private UI_name ui => (UI_name)uiComponent;

        public override void OnOpen( object data )
        {
            Debug.Log( $"设置名字界面" );
            
            ui.confirm_btn.onClick.Set( () =>
            {
                if( !string.IsNullOrEmpty( ui.name_txt.text ) )
                {
                    ContextHelper.name = ui.name_txt.text;
                    UIHelper.OpenView<TipView>( typeof(UI_tip), 0 );
                    Close();
                }
                else
                {
                    Debug.Log( $"需要输入宠物的名字!" );
                }
            } );
        }
    }
}