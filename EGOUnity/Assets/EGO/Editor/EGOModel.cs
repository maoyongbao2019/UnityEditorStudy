﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EGO {
    [Serializable]
    public class TodoList {
        public static TodoList Load() {
            var todoCenent = EditorPrefs.GetString("EGO_TODOS", string.Empty);
            if (string.IsNullOrEmpty(todoCenent)) {
                return new TodoList();
            }
            //try {
            //    var deprecated = JsonUtility.FromJson<Deprecated.TodoList>(todoCenent);
            //    if (deprecated != null && deprecated.todos.Count > 0) {
            //        Debug.Log("开始升级数据结构！");
            //        var todos = deprecated.todos.Select(todo => new Todo() { Content = todo, Finished = false }).ToList();
            //        todoCenent = JsonUtility.ToJson(new TodoList() { todos = todos });
            //        EditorPrefs.SetString("EGO_TODOS", todoCenent);
            //    }
            //}catch(Exception e) {
            //    Console.WriteLine(e);
            //    throw;
            //}

            //获取上次存储的值
            return JsonUtility.FromJson<TodoList>(todoCenent);
        }

        public void Save() {
            //存储值
            EditorPrefs.SetString("EGO_TODOS", JsonUtility.ToJson(this));
        }

        public List<Todo> todos = new List<Todo>();
    }

    [Serializable]
    public class Todo {
        public string Content;
        public bool Finished;
    }
}

//弃用的model
namespace EGO.Deprecated {
  
    [Serializable]
    public class TodoList {
        public List<string> todos = new List<string>();
    }

}