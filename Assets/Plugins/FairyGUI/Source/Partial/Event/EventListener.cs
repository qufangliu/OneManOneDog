#if FAIRYGUI_XLUA

using XLua;

namespace FairyGUI
{
    public partial class EventListener
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="func"></param>
        /// <param name="self"></param>
        public void Add(LuaFunction func, LuaTable self)
        {
            _bridge.Add(func, self);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="func"></param>
        /// <param name="self"></param>
        public void Remove(LuaFunction func, LuaTable self)
        {
            _bridge.Remove(func, self);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="func"></param>
        /// <param name="self"></param>
        public void Set(LuaFunction func, LuaTable self)
        {
            _bridge.Clear();
            if (func != null)
                Add(func, self);
        }
    }
}

#endif