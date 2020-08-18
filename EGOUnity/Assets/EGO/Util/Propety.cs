/****************************************************
    文件：Propety.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using System;
using UnityEngine;
namespace EGO.Util {
    [Serializable]
    public class InitProperty : Propety<int> {
        public int Value {
            get { return base.value; }
            set { base.value = value; }
        }
    }

    [Serializable]
    public class Propety<T>{
        public Propety() {

        }

        public Propety(T initValue) {
            mValue = initValue;
        }

        public T value {
            get => mValue;
            set {
                if (!value.Equals(mValue)) {
                    mValue = value;
                    mOnValueChangedEvent?.Invoke();
                }
            }
        }

        private T mValue = default(T);

        event Action mOnValueChangedEvent;

        public void RegisterValueChanged(Action onValueChanged) {
            mOnValueChangedEvent += onValueChanged;
        }

    }
}
