using FairyGUI;
using UnityEngine;

namespace UI
{
    public class ViewBase : MonoBehaviour
    {
        public GComponent uiComponent;
        
        public virtual void OnOpen( object data )
        {
            
        }

        public virtual void OnClose()
        {
            
        }

        public virtual void Close()
        {
            if( uiComponent != null )
            {
                OnClose();
                // 销毁UI
                uiComponent.RemoveFromParent();
                uiComponent.Dispose();
            }
        }
    }
}