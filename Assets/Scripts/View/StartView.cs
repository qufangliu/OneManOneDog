using UI;
using ui.Main;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadSceneAsync("Fight");
            } );
        }
    }
}