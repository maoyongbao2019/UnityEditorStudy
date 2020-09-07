

using UnityEngine;

namespace EGO.Framework{
    public class HorizontalLayout : Layout {
        protected override void OnGUIBegin() {
            GUILayout.BeginHorizontal();
        }

        protected override void OnGUIEnd() {
            GUILayout.EndHorizontal();
        }
    }
}
