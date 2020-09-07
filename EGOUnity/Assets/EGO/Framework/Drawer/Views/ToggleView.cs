
using UnityEngine;

namespace EGO.Framework {
    public class ToggleView : View {
        public ToggleView(string text, bool initValue = false) {
            Text = text;
            Toggle = new Property<bool>(initValue);
        }

        public string Text { get; }

        public Property<bool> Toggle { get; private set; }
        protected override void OnGUI() {
            Toggle.value = GUILayout.Toggle(Toggle.value, Text);
        }
    }
}
