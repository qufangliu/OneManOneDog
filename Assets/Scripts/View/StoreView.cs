using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class StoreView : ViewBase
    {
        private UI_store ui => (UI_store)uiComponent;

        public override void OnOpen( object data )
        {
            Debug.Log( $"回家路上路过商店" );
            
            ui.jump_btn.onClick.Set( () =>
            {
                UIHelper.OpenView<DogView>( typeof(UI_dog) );
                Close();
            } );
        }
    }
}