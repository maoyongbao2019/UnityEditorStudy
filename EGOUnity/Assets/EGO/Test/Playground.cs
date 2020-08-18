/****************************************************
    文件：Playground.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using EGO.Util;
using UnityEngine;
namespace Tests {
    public class Playground {
        public void PlaygroundSimplePasses() {
            var p = new InitProperty();
            p.Value = 10;
            Debug.Log(JsonUtility.ToJson(p));
        }
    }
}
