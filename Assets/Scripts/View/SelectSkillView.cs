using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class SelectSkillView : ViewBase
    {
        private UI_skill ui => (UI_skill)uiComponent;

        public override void OnOpen( object data )
        {
            ui.start_btn.onClick.Set( () =>
            {
                Debug.Log( $"进入游戏" );
                UIHelper.OpenView<BattleView>( typeof(UI_hud) );
                Close();
            } );
        }
    }
}