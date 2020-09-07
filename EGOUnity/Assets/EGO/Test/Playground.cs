/****************************************************
    文件：Playground.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using EGO.Framework;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
namespace Tests {
    public class Playground {
        [Test]
        public void PlaygroundSimplePasses() {
            var p = new Property<bool>();
            p.value = false;
            string jsonValue = JsonConvert.SerializeObject(p);
            Debug.Log(JsonConvert.DeserializeObject<Property<bool>>(jsonValue));
            Assert.IsTrue(true);
        }
    }
}
