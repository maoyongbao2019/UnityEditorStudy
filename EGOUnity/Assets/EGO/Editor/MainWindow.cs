/****************************************************
    文件：MainWindow.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EGO {

    public class MainWindow : EditorWindow {
        private bool curtDisplayStatus = false; //当前窗口显示状态

        [MenuItem("EGO/MainWindow %#w")] // 空格后表示快捷键ctrl(%)shift(#)W(w)
        static void Open() {
            var window = GetWindow<MainWindow>();//GetWindow(typeof(MyWindow))
            //设置当前窗口的状态  实现一开一关
            if (!window.curtDisplayStatus) {
                //获取上次存储的值
                window.mTodoList = TodoList.Load();
                window.Show();
                window.curtDisplayStatus = true;
            }
            else {
                window.Close();
                window.curtDisplayStatus = false;
            }
        }

        TodoList mTodoList = new TodoList(); //待办事项

        private string mInputContent = string.Empty;
        private void OnGUI() {
            //GUILayout.Label("测试");
            mInputContent = EditorGUILayout.TextArea(mInputContent); 

            if (GUILayout.Button("添加")) {
                if (!string.IsNullOrEmpty(mInputContent)) {
                    mTodoList.todos.Add(new Todo() { Content = mInputContent });
                    mInputContent = string.Empty;
                }
            }

            for(int i=mTodoList.todos.Count-1;i>=0;i--) {
                var todo = mTodoList.todos[i];
                EditorGUILayout.BeginHorizontal();
                todo.Finished = GUILayout.Toggle(todo.Finished, todo.Content);
                if (GUILayout.Button("删除")) { //右边删除按钮
                    mTodoList.todos.RemoveAt(i);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
