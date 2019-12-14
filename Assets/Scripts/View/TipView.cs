using UI;
using ui.Main;
using UnityEngine;

namespace View
{
    public class TipView : ViewBase
    {
        private UI_tip ui => (UI_tip)uiComponent;

        private float totalTime;
        private bool closeEnable;
        
        public override void OnOpen( object data )
        {
            Debug.Log( "说明界面" );
            
            if( data is string )
            {
                // 内容
                ui.content_txt.text = (string)data;
            }
            else if( data is int )
            {
                // 内容切换
                ui.content.selectedIndex = (int)data;
            }
            
            ui.skip_btn.onClick.Set( () =>
            {
                if( closeEnable )
                {
                    UIHelper.OpenView<SelectSkillView>( typeof(UI_skill) );
                    Close();
                }
            } );
        }

        public void Update()
        {
            totalTime += Time.deltaTime;
            if( totalTime > 2 )
            {
                closeEnable = true;
            }
        }
    }
}