using System;
using System.Collections.Generic;
using UnityEngine;

namespace EGO.Deprecated {
    [Serializable]
    public class TodoList {
        public List<Todo> Todos = new List<Todo>();
    }

    [Serializable]
    public class Todo {
        public string Content;
        public bool Finished;
        public bool FinishedValue {
            get => Finished;
            set {
                if (value != Finished) {
                    FinishedChanged = true; //这种方式，外界访问该变量可以控制执行的次数，而在内部使用委托的方式执行次数得不到控制
                    Finished = value;
                    Debug.Log("Finished:" + value);
                }
            }
        }
        public bool FinishedChanged { get; set; }
    }
}
