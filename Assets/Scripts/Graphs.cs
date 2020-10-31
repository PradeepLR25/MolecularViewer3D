using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Graphs
{

    public class Graph<T> {


    
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        public Graph()
        {

        }
        
        public int Count
        {
            get {
                return nodes.Count;
                }
        }

        public List<GraphNode<T>> Nodes
        {
            get { 
                return nodes;
                }
        }

        public bool AddNode(T value){
            if(Find(value) != null){
                return false;
            }else{
                nodes.Add(new GraphNode<T>(value));
                return true;
            }
        }


        public bool AddEdge(T value1, T value2){
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if(node1 == null || node2 == null){
                return false;
            }else if(node1.Neighbors.Contains(node2)){
                return false;
            }else{
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
                return true;
            }
        }


        public GraphNode<T> Find(T value){
            foreach(GraphNode<T> node in nodes){
                if(node.Value.Equals(value)){
                    return node;
                }
            }
            return null;
        }

    
    }


}