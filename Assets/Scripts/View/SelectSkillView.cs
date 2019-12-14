using UI;
using ui.Main;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class SelectSkillView : ViewBase
    {
        private UI_skill ui => (UI_skill)uiComponent;

        public override void OnOpen( object data )
        {
            Debug.Log( $"选择技能界面" );

            // 设置为非遛狗状态
            ContextHelper.walk = false;
            
            ui.start_btn.onClick.Set( () =>
            {
                Debug.Log( $"进入游戏" );
                UIHelper.OpenView<BattleView>( typeof(UI_hud) );
                Close();
            } );
        }
    }
}