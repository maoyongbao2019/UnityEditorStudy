/****************************************************
    文件：CustomView.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using EGO.Framework;
using System;
using UnityEngine;
namespace EGO.Framework {
    public class CustomView : View {
        public CustomView(Action OnGuiAction) {
            OnGUIAction = OnGuiAction;
        }
        public Action OnGUIAction { get; set; }

        protected override void OnGUI() {
            if (OnGUIAction == null)
                Debug.LogError("OnGUIAction is Empty");
            else
                OnGUIAction();
        }
    }
}
