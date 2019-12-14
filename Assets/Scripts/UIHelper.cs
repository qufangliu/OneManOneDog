/**
 * UI管理器
 */

using System;
using FairyGUI;
using UI;
using ui.Main;

public static class UIHelper
{
    /// <summary>
    /// 初始化UI
    /// </summary>
    public static void InitUI()
    {
        GRoot.inst.SetContentScaleFactor( 1334, 750, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight );
        // 初始化UI资源
        UIPackage.AddPackage( "UI/Main" );
        MainBinder.BindAll();
    }

    /// <summary>
    /// 打开UI
    /// </summary>
    /// <param name="uiType"></param>
    /// <typeparam name="T"></typeparam>
    public static void OpenView<T>(Type uiType, object data = null) where T:ViewBase
    {
        var uiName = uiType.Name.Replace( "UI_", "" );
        var ui = UIPackage.CreateObject( "Main", uiName ).asCom;
        GRoot.inst.AddChild( ui );
        var view = ui.displayObject.gameObject.AddComponent<T>();
        view.uiComponent = ui;
        view.OnOpen( data );
    }
}