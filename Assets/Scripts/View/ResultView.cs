using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class ResultView : ViewBase
    {
        private UI_result ui => (UI_result)uiComponent;

        public override void OnOpen( object data )
        {
            ui.state.selectedIndex = (int)data;

            if( ui.state.selectedIndex == 0 )
            {
                Debug.Log( "战斗结算" );
                // 战斗结算
                ui.onClick.Set( () =>
                {
                    UIHelper.OpenView<StoreView>( typeof(UI_store) );
                    Close();
                } );
            }
            else if( ui.state.selectedIndex == 1 )
            {
                Debug.Log( "今日结算" );
                // 日结算
                ui.onClick.Set( () =>
                {
                    Debug.Log( "开始新的一天" );
                    UIHelper.OpenView<SelectSkillView>( typeof(UI_skill) );
                    Close();
                } );
            }
        }
    }
}