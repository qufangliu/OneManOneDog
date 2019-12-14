#if FAIRYGUI_XLUA

using System.Collections.Generic;
using XLua;

namespace FairyGUI
{
    public partial class EventBridge
    {
        private Dictionary<LuaFunction, EventCallback1> _cacheCallback1;
        private Dictionary<LuaFunction, EventCallback1> cacheCallback1 => _cacheCallback1 ?? (_cacheCallback1 = new Dictionary<LuaFunction, EventCallback1>());

        public void Add(LuaFunction func, LuaTable self)
        {
            EventCallback1 callback = (context) =>
            {
                func.Call(self, context);
            };
            // cache
            cacheCallback1.Add(func, callback);
            // add callback
            _callback1 -= callback;
            _callback1 += callback;
        }

        public void Remove(LuaFunction func, LuaTable self)
        {
            if (cacheCallback1.ContainsKey(func))
            {
                var callbacl1 = cacheCallback1[func];
                // remove callback
                _callback1 -= callbacl1;
                // clear cache
                cacheCallback1.Remove(func);
            }
        }
    }
}

#endif