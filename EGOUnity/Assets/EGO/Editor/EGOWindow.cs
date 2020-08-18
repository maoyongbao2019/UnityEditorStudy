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

    public class EGOWindow : EditorWindow {
        private bool curtDisplayStatus = false; //当前窗口显示状态

        [MenuItem("EGO/MainWindow %#w")] // 空格后表示快捷键ctrl(%)shift(#)W(w)
        static void Open() {
            var window = GetWindow<EGOWindow>(true);//GetWindow(typeof(MyWindow)),参数true设置为固定窗口
            //设置当前窗口的状态  实现一开一关
            if (!window.curtDisplayStatus) {
                //获取上次存储的值
              
                window.mTodoList = TodoList.Load();
                var texture =  Resources.Load<Texture2D>("1DSC_00004"); //从resources文件夹中加载资源
                window.titleContent = new GUIContent("EGO Window", texture);//设置窗口标题以及Icon
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
            GUILayout.Space(10);

            GUILayout.BeginVertical("box");

            mInputContent = EditorGUILayout.TextArea(mInputContent); 

            if (GUILayout.Button("添加")) {
                if (!string.IsNullOrEmpty(mInputContent)) {
                    mTodoList.todos.Add(new Todo() { Content = mInputContent });
                    mTodoList.Save();
                }
            }
            GUILayout.EndVertical();

            GUILayout.Space(10);
            //添加的布局
            GUILayout.BeginVertical("box");
            for (int i=mTodoList.todos.Count-1;i>=0;i--) {
                var todo = mTodoList.todos[i];
                #region 编写每行的菜单
                EditorGUILayout.BeginHorizontal();
                todo.FinishedValue = GUILayout.Toggle(todo.FinishedValue, todo.Content);

                if (todo.FinishedChanged) {
                    todo.FinishedChanged = false;
                    mTodoList.Save();
                }

                if (GUILayout.Button("删除")) { //右边删除按钮
                    mTodoList.todos.RemoveAt(i);
                    mTodoList.Save();
                }
                EditorGUILayout.EndHorizontal();
                #endregion
            }
            GUILayout.EndVertical();
        }
    }
}
