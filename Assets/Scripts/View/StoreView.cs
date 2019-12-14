using UI;
using ui.Main;

namespace View
{
    public class StoreView : ViewBase
    {
        private UI_store ui => (UI_store)uiComponent;

        public override void OnOpen( object data )
        {
            ui.jump_btn.onClick.Set( () =>
            {
                UIHelper.OpenView<DogView>( typeof(UI_dog) );
                Close();
            } );
        }
    }
}