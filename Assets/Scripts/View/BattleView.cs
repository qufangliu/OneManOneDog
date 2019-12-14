using System;
using UI;
using ui.Main;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View
{
    public class BattleView : ViewBase
    {
        public UI_hud ui => (UI_hud)uiComponent;

        private float totalTime;
        private bool closeEnable;

        private Action<int> _action;
        
        private void Start()
        {
        }

        private void FindPlayer(AsyncOperation obj)
        {
            
        }

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
            ui.health_bar.value = ContextHelper.playerMood;
            ui.dog_health_bar.value = ContextHelper.dogMood;
            // totalTime += Time.deltaTime;
            // if( totalTime > 3 )
            // {
            //     closeEnable = true;
            //     // 场景结算(0:战斗 1:探险)
            //     UIHelper.OpenView<ResultView>( typeof(UI_result), ContextHelper.walk ? 1 :0 );
            //     Close();
            // }
        }
    }
}