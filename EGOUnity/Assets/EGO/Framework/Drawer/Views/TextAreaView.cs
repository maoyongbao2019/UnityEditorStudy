/****************************************************
    文件：TextAreaView.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEditor;
using UnityEngine;
namespace EGO.Framework {
    public class TextAreaView : View {
        public TextAreaView(string content) {
            Content = new Property<string>(content);
        }

        public Property<string> Content { get; set; }
        protected override void OnGUI() {
            Content.value = EditorGUILayout.TextArea(Content.value);
        }
    }
}
