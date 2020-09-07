/****************************************************
    文件：MainWindow.cs
	作者：MaoYaoBao
    邮箱: 2128862889@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/
using EGO.Framework;
using EGO.Util;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace EGO {
    public class EGOWindow : EditorWindow {
        private bool curtDisplayStatus = false; //当前窗口显示状态

        [MenuItem("EGO/MainWindow %#w")] // 空格后表示快捷键ctrl(%)shift(#)W(w)
        static void Open() {
            var window = GetWindow<EGOWindow>(true);//GetWindow(typeof(MyWindow)),参数true设置为固定窗口
            //设置当前窗口的状态  实现一开一关
            if (!window.curtDisplayStatus) {
                //获取上次存储的值
              
                window.mTodoList = ModelLoader.Load();
                var texture =  Resources.Load<Texture2D>("1DSC_00004"); //从resources文件夹中加载资源
                window.titleContent = new GUIContent("EGO Window", texture);//设置窗口标题以及Icon
                window.Init();
                window.Show();
                window.curtDisplayStatus = true;

                window.mTodoList.todos.ForEach(todo => todo.Finished.Bind(_ => window.mTodoList.Save()));
            }
            else {
                window.mTodoList.todos.ForEach(todo => todo.Finished.UnBindAll());
                window.curtDisplayStatus = false;
                window.Close();
            }
        }

        void Init() {
            mViews.Add(new SpaceView());
            //box VerticalLayout
            VerticalLayout layout = new VerticalLayout("box");
            TextAreaView inputTextArea = new TextAreaView(mInputContent);
            inputTextArea.Content.Bind(newContent => mInputContent = newContent);
            layout.AddChild(inputTextArea);
            layout.AddChild(new ButtonView("添加", () => {
                if (!string.IsNullOrEmpty(mInputContent)) {
                    var newTodo = new Todo() { Content = mInputContent };
                    newTodo.Finished.Bind(_ => mTodoList.Save());
                    mTodoList.todos.Add(newTodo);
                    mTodoList.Save();
                    Debug.Log(JsonUtility.ToJson(mTodoList));
                }
            }));
            mViews.Add(layout);
            mViews.Add(new SpaceView());
            //为两个button进行绑定
            mShowUnFinishedButton = new ButtonView("显示未完成", () => {
                mShowFinished = false;
                this.mShowUnFinishedButton.Hide();
                this.mShowFinishedButton.Show();
            });
            mShowFinishedButton = new ButtonView("显示已完成", () => {
                mShowFinished = true;
                this.mShowUnFinishedButton.Show();
                this.mShowFinishedButton.Hide();
            });
            mShowFinishedButton.Show(); 
            mShowUnFinishedButton.Hide();//默认显示未完成
            mViews.Add(mShowFinishedButton);
            mViews.Add(mShowUnFinishedButton);
            // layout = new VerticalLayout("box");
            var boxlayout = new VerticalLayout("box");
            foreach(var todo in mTodoList.todos.Where(todo => todo.Finished.value == mShowFinished)) {
                var horizontallayout = new HorizontalLayout();
                var toggleView = new ToggleView(todo.Content, todo.Finished.value);
                toggleView.Toggle.Bind(value => { todo.Finished.value = value; });
                horizontallayout.AddChild(toggleView);
                var buttonView = new ButtonView("删除", () => {
                    todo.Finished.UnBindAll();
                    mTodoList.todos.Remove(todo);
                    mTodoList.Save();
                });
                horizontallayout.AddChild(buttonView);
                boxlayout.AddChild(horizontallayout);
            }
            mViews.Add(boxlayout);
        }
        private ButtonView mShowUnFinishedButton = null;
        private ButtonView mShowFinishedButton = null;

        TodoList mTodoList = new TodoList(); //待办事项

        private bool mShowFinished = false;//用于折叠，显示已完成的行

        private string mInputContent = string.Empty;

        private List<IView> mViews = new List<IView>();
        private void OnGUI() {
            //GUILayout.Label("测试");
            mViews.ForEach(view => view.DrawGUI());  
        }
    }
}
