using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class BattleView : ViewBase
    {
        public UI_hud ui => (UI_hud)uiComponent;

        private float totalTime;
        private bool closeEnable;

        public override void OnOpen( object data )
        {
            if( ContextHelper.walk )
            {
                Debug.Log( "遛狗场景" );
            }
            else
            {
                Debug.Log( "战斗场景" );
            }
        }

        public void Update()
        {
            totalTime += Time.deltaTime;
            if( totalTime > 3 )
            {
                closeEnable = true;
                // 场景结算(0:战斗 1:探险)
                UIHelper.OpenView<ResultView>( typeof(UI_result), ContextHelper.walk ? 1 :0 );
                Close();
            }
        }
    }
}