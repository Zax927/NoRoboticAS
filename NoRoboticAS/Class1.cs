using System;
using System.Collections.Generic;
using UnityEngine;


namespace NoRoboticAS
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class NoRoboticAS : MonoBehaviour
    {
        void Update()
        {
            bool unASKey = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.P);
            List<Part> parts = EditorLogic.fetch.ship.Parts;

            void RefreshParts()
            {
                parts = EditorLogic.fetch.ship.Parts;
            }

            if (unASKey)
            {
                RefreshParts();
                foreach(Part p in parts)
                {
                    if (p.isRobotic()){
                        Part.AutoStrutMode prMode = p.autoStrutMode;

                        p.autoStrutMode = Part.AutoStrutMode.Off;
                        Debug.Log("Autostruts removed from " + p + ". Previous state " + prMode);
                    }
                }

                ScreenMessages.PostScreenMessage("Autostruts removed from robotic parts", 3);
            }

            /*bool testKey = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.T);
            if (testKey)
            {
                ScreenMessages.PostScreenMessage("NoRoboticAS test key pressed", 3);
            }*/
        }
    }
}
