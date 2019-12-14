using ui.Main;
using UnityEngine;
using View;

/**
 * 游戏启动脚本
 */
public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "游戏开始!" );
        UIHelper.InitUI();
        UIHelper.OpenView<StartView>( typeof(UI_start) );
    }
}
