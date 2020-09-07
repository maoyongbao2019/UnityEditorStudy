/****************************************************
    文件：Space.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using EGO.Framework;
using UnityEngine;

namespace EGO.Framework {
    public class SpaceView : View {
        public int Pixel { get; set; }
        public SpaceView(int pixel = 10) {
            Pixel = pixel;
        }
        protected override void OnGUI() {
            GUILayout.Space(Pixel);
        }
    }
}
