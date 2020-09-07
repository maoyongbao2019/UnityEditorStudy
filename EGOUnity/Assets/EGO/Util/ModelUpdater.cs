using Newtonsoft.Json;
using UnityEngine;
using System.Linq;
using EGO.Framework;

namespace EGO.Util {
    //没办法序列化的时候更新数据库
    public static class ModelUpdater {
        public static string Update(object oldValue) {
            var deprecated = oldValue as Deprecated.TodoList;
            if (deprecated != null && deprecated.Todos.Count > 0) {
                //使用Linq查询语句把老版本的todo转化新版本
                var newVersionTodos = deprecated.Todos.Select(todo => new Todo() {
                    Content = todo.Content,
                    Finished = new Property<bool>(todo.Finished)
                }).ToList();

                var newVersionTodoList = new TodoList() {
                    todos = newVersionTodos
                };
                Debug.Log("开始升级数据结构！");
                
                newVersionTodoList.Save();
                //var todos = deprecated.todos.Select(todo => new Todo() { Content = todo, Finished = false }).ToList();
                //todoCenent = JsonConvert.SerializeObject(new TodoList() { todos = todos });
                //EditorPrefs.SetString("EGO_TODOS", todoCenent);
                return JsonConvert.SerializeObject(newVersionTodoList);
            }
            return string.Empty;
        }
    }
}
