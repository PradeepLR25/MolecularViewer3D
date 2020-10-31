using System;
using System.Collections.Generic;
using System.Text;
using Graphs;
using UnityEngine;

namespace Graphs
{
    public class GraphNode<T> {
        T value;
        List<GraphNode<T>> neighbors;
        public double[] coordinates;
        public string AtomType;
        public string AtomID;
        public double temperatureFactor;
        public int ResNum;
        public string ResName;

        public GraphNode(T value){
            this.value = value;
            // this.AtomType = AtomType;
            // this.AtomID = AtomID;
            neighbors = new List<GraphNode<T>>();
            // this.coordinates = coordinates;
            // this.temperatureFactor = temperatureFactor;
        }

        public bool AddParameters(double[] coordinates, string AtomType, string AtomID, double temperatureFactor, int ResNum, string ResName){
            try{
            this.AtomType = AtomType;
            this.AtomID = AtomID;
            this.coordinates = coordinates;
            this.temperatureFactor = temperatureFactor;
            this.ResNum = ResNum;
            this.ResName = ResName;
            return true;
            }
            catch(ArgumentException e){
                Debug.Log(e);
                return false;
            }
        }

        public T Value{
            get { return value;}
        }


        public IList<GraphNode<T>> Neighbors
        {
            get{ return neighbors.AsReadOnly();}
        }

        public bool AddNeighbor(GraphNode<T> neighbor)
        {
            if(neighbors.Contains(neighbor)){
                return false;
            }else{
                neighbors.Add(neighbor);
                return true;
            }
        }


        // public bool RemoveNeighbor(GraphNode<T> neighbor)
        // {
        //     return neighbor.Remove(neighbor);
        // }
    }
}