using Newtonsoft.Json;
using System;
using UnityEditor;
using UnityEngine;

namespace EGO.Util {
    public static class ModelLoader {
        private const string Key = "EGO_TODOS";
        public static TodoList Load() {
            var todoCenent = EditorPrefs.GetString("EGO_TODOS", string.Empty);
            if (string.IsNullOrEmpty(todoCenent)) {
                return new TodoList();
            }
            try {
                var deprecated = JsonConvert.DeserializeObject<Deprecated.TodoList>(todoCenent);

                todoCenent = ModelUpdater.Update(deprecated);
            }
            catch {
                //由于错误操作导致每次都转换失败，所以尝试转换为最新版本
                try {
                    return JsonConvert.DeserializeObject<TodoList>(todoCenent);
                }
                catch (Exception e) {
                    EditorPrefs.SetString("EGO_TODOS", string.Empty);
                    Debug.LogError("无论旧版本还是新版本都转换失败！！ErrorMsg:" + e.Message);
                    return new TodoList();
                }
            }
            //获取上次存储的值
            return JsonConvert.DeserializeObject<TodoList>(todoCenent);
        }

        public static void Save(this TodoList todoList) {
            //string value = JsonConvert.SerializeObject(this); //键值对序列化，只序列化public的成员变量
            //存储值
            EditorPrefs.SetString("EGO_TODOS", JsonConvert.SerializeObject(todoList));
        }
    }
}
