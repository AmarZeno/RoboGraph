using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGGraphCore
{
    class RGTreeNode<T>
    {
        public RGTreeNode<T> Parent { get; set; }
        public List<RGTreeNode<T>> Children { get; set; }
        public T Data { get; set; }

        public RGTreeNode(T data)
        {
            this.Data = data;
            this.Children = new List<RGTreeNode<T>>();
        }

        public void AddChild(RGTreeNode<T> child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public string SubTreeToString()
        {
            string tree = this.Data.ToString();
            if(this.Children.Count > 0)
            {
                tree += "(";
                for(int i = 0; i< this.Children.Count; i++)
                {
                    tree += this.Children[i].SubTreeToString();
                    if(i < this.Children.Count - 1)
                    {
                        tree += ", ";
                    }
                }
                tree += ")";
            }
            return tree;
        }
    }
}