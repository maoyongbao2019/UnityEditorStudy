/****************************************************
    文件：View.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace EGO.Framework {
    public abstract class View : IView {
        public bool Visible { get; set; } = true;
        public void Show() {
            Visible = true;
        }
        public void Hide() {
            Visible = false;
        }
        public void DrawGUI() {
            if (Visible) {
                OnGUI();
            }
        }
        protected abstract void OnGUI();
    }
}
