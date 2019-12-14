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
            Debug.Log( "战斗场景" );
        }

        public void Update()
        {
            totalTime += Time.deltaTime;
            if( totalTime > 3 )
            {
                closeEnable = true;
                // 结算
                UIHelper.OpenView<ResultView>( typeof(UI_result), 0 );
                Close();
            }
        }

        private void EndTheDay()
        {
            UIHelper.OpenView<ResultView>( typeof(UI_result), 1 );
            Close();
        }
    }
}