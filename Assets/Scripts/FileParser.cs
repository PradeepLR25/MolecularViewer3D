using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using Graphs;

// public interface TestRead{
//     void readfile();
// }

public class FileParser
//, TestRead
{
    public Dictionary<string, List<int>> AAsequence = new Dictionary<string, List<int>>();
    public Graphs.Graph<int> Protein;// = new Graphs.Graph<int>();
    public void readfile(){
        
        

        string path = Directory.GetCurrentDirectory();

        string pathParent = Path.Combine(path, "Assets");

        string fileT = "1gcn.pdb";
        string pathFile = Path.Combine(pathParent,fileT);

        string[] lines = File.ReadAllLines(pathFile);
        string line;

        char[] delimiterChar = {' ', '\t'};
        Protein = new Graphs.Graph<int>();
        for (int i = 0; i<lines.Length; i++) 
        {
            line = lines[i];
            string[] words = line.Split(delimiterChar, StringSplitOptions.RemoveEmptyEntries);

            
            if(words[0].Equals("ATOM")){
                string ID = words[5] + " " + words[3];
                int value;
                double x, y, z;
                string AtomType = words[2];
                double tempFactor;
                int ResNum;
                string ResName;

                try{
                    value = Int32.Parse(words[1]);
                    x = Convert.ToDouble(words[6]);
                    y = Convert.ToDouble(words[7]);
                    z = Convert.ToDouble(words[8]);
                    tempFactor = Convert.ToDouble(words[10]);
                    ResNum = Int32.Parse(words[5]);
                    ResName = words[3];
                    double[] coord = {x, y, z};
                    
                    Protein.AddNode(value);
                    Graphs.GraphNode<int> instance = Protein.Find(value);
                    instance.AddParameters(coord, AtomType, ID, tempFactor, ResNum, ResName);

                    if(AAsequence.ContainsKey(ID)){
                        AAsequence[ID].Add(value);
                    }else{
                        List<int> newAA = new List<int>();
                        newAA.Add(value);
                        AAsequence.Add(ID, newAA);
                    }
                }
                catch (FormatException e){
                    Debug.Log(e);
                }
            

            }

            }
            
        }
        
    }

