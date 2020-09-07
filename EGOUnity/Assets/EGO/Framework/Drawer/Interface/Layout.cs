
using System.Collections.Generic;

namespace EGO.Framework {
    public abstract class Layout:View,ILayout{
        private List<IView> Children = new List<IView>();
        public void AddChild(IView view) {
            Children.Add(view);
        }
        public void RemoveChild(IView view) {
            Children.Remove(view);
        }

        protected override void OnGUI() {
            OnGUIBegin();
            foreach (var child in Children) {
                child.DrawGUI();
            }
            OnGUIEnd();
        }

        protected abstract void OnGUIBegin();
        protected abstract void OnGUIEnd();
    }
}
