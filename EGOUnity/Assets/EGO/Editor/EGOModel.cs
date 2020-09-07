using EGO.Framework;
using System;
using System.Collections.Generic;

namespace EGO {
    [Serializable]
    public class TodoList {
        
        

        public List<Todo> todos = new List<Todo>();
    }

    [Serializable]
    public class Todo {
        public string Content;
        public Property<bool> Finished = new Property<bool>();
    }
}
 
