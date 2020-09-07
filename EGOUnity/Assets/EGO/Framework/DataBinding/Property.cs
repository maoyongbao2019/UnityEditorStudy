/****************************************************
    文件：Propety.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace EGO.Framework {
    [Serializable]
    public class InitProperty : Property<int> {
        public int Value {
            get { return base.value; }
            set { base.value = value; }
        }
    }

    [Serializable]
    public class Property<T>{
        public Property() {

        }

        public Property(T initValue) {
            mValue = initValue;
        }

        public T value {
            get => mValue;
            set {
                if (!value.Equals(mValue)) {
                    mValue = value;
                    //mOnValueChangedEvent?.Invoke();
                    mSetter?.Invoke(mValue);
                }
            }
        }

        private T mValue = default(T);

        /// <summary>
        /// 注销功能也要完成
        /// </summary>
        /// <param name="setter"></param>
        public void Bind(Action<T> setter,Func<T> getter = null) {
            //RegisterValueChanged(() => {
            //    setter(mValue);
            //});
            mSetter += setter;
            mBindings.Add(mSetter);
            if (getter != null) {
                mGetter = getter;
            }
        }

        public void UnBindAll() {
            foreach(var binding in mBindings) {
                mSetter -= binding;
            }
            mBindings.Clear();
        }

        List<Action<T>> mBindings { get; set; } = new List<Action<T>>();
        private event Action<T> mSetter;
        private Func<T> mGetter;

        //private event Action mOnValueChangedEvent;

        //public void RegisterValueChanged(Action onValueChanged) {
        //    mOnValueChangedEvent += onValueChanged;
        //}

        //public void UnRegisterValueChanged(Action onValueChanged) {
        //    mOnValueChangedEvent -= onValueChanged;
        //}
    }
}
