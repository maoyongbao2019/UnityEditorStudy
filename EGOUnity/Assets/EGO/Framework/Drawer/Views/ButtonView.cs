/****************************************************
    文件：ButtonView.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace EGO.Framework {
    public class ButtonView : View {
        public ButtonView(string text, Action onClickEvent) {
            Text = text;
            OnClickEvent = onClickEvent;
        }

        public string Text { get; set; }
        public Action OnClickEvent { get; set; }
        protected override void OnGUI() {
            if (GUILayout.Button(Text)) {
                OnClickEvent.Invoke();
            }
        }
    }
}
