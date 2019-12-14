using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

#if UNITY_EDITOR
namespace FairyGUI
{
    public class FguiTouchSimulator
    {
        public static bool simulateOn = false;
        public static GObject simulateTouchPoint;
        public const int simulateTouchPointId = 999;

        private const float simulateTouchPointSpeed = 4f;


        public static void UpdateSimulateTouch()
        {
            if (simulateTouchPoint == null)
            {
                GGraph holder = new GGraph();
                holder.SetSize(10, 10);
                holder.DrawEllipse(10, 10, Color.yellow);
                simulateTouchPoint = GRoot._inst.AddChild(holder);
                simulateTouchPoint.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
                simulateTouchPoint.visible = simulateOn;
            }

            bool moved = false;
            if (Input.GetKey("w"))
            {
                simulateTouchPoint.position = simulateTouchPoint.position + Vector3.down * simulateTouchPointSpeed;
                moved = true;
            }

            if (Input.GetKey("s"))
            {
                simulateTouchPoint.position = simulateTouchPoint.position + Vector3.up * simulateTouchPointSpeed;
                moved = true;
            }

            if (Input.GetKey("a"))
            {
                simulateTouchPoint.position = simulateTouchPoint.position + Vector3.left * simulateTouchPointSpeed;
                moved = true;
            }

            if (Input.GetKey("d"))
            {
                simulateTouchPoint.position = simulateTouchPoint.position + Vector3.right * simulateTouchPointSpeed;
                moved = true;
            }

            if (moved && Input.GetKey("z"))
            {
                Stage.inst.onTouchMove.BubbleCall(new InputEvent()
                {
                    touchId = simulateTouchPointId, x = simulateTouchPoint.position.x, y = simulateTouchPoint.position.y
                });
            }


            if (Input.GetKeyDown("z"))
            {
                Stage.inst.AddTouchCount(1);
                Stage.inst.onTouchBegin.BubbleCall(new InputEvent()
                {
                    touchId = simulateTouchPointId, x = simulateTouchPoint.position.x, y = simulateTouchPoint.position.y
                });
            }

            if (Input.GetKeyUp("z"))
            {
                Stage.inst.AddTouchCount(-1);
                Stage.inst.onTouchEnd.BubbleCall(new InputEvent()
                {
                    touchId = simulateTouchPointId, x = simulateTouchPoint.position.x, y = simulateTouchPoint.position.y
                });
            }
        }
    }
}
#endif