/****************************************************
    文件：VerticalLayout.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using UnityEngine;
namespace EGO.Framework {
    public class VerticalLayout : Layout {
        public string Style { get; set; }
        public VerticalLayout(string style = null) {
            Style = style;
        }  

        protected override void OnGUIBegin() {
            if (Style == null)
                GUILayout.BeginVertical();
            else
                GUILayout.BeginVertical(Style);
        }

        protected override void OnGUIEnd() {
            GUILayout.EndVertical();
        }
    }
}
