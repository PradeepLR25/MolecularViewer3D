using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Graphs;


public class AtomCreator : MonoBehaviour
{
    public GameObject Atom1;
    public GameObject Bond;
    public FileParser FP;
    public AADefinitions AADef;
    public GameObject CameraCenter;
    // Start is called before the first frame update
    void Start()
    {   

        FP = new FileParser();
        FP.readfile();
        float x, y, z;
        AADef = new AADefinitions();

        Dictionary<string, List<(string, string)>> Connections = new Dictionary<string, List<(string, string)>>();
        Connections = AADef.ConnectionsList;

        List<GraphNode<int>> AllNodes = new List<GraphNode<int>>();

        AllNodes = FP.Protein.Nodes;
        string TempAtomName;
        int ResNum;
        string ResName;
        print(AllNodes.Count);
        float sumx = 0;
        float sumy = 0;
        float sumz = 0;

        foreach (var node1 in AllNodes){
            //print(node.Value);
            print(node1.coordinates[0]);
             x = (float)node1.coordinates[0];
             sumx +=x;
             y = (float)node1.coordinates[1];
             sumy += y;
             z = (float)node1.coordinates[2];
             sumz += z;
            var newAtom = Instantiate(Atom1, new Vector3(x, y, z), Quaternion.identity);
            char AtomName = node1.AtomType[0];
            if(AtomName == 'C'){
                newAtom.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
            }else if(AtomName == 'N'){
                newAtom.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
            }else if(AtomName == 'O'){
                newAtom.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            }else if(AtomName == 'S'){
                newAtom.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
            }else{
                newAtom.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
            }

            ResNum = node1.ResNum;
            ResName = node1.ResName;
            TempAtomName = node1.AtomType;

            foreach (var node2 in AllNodes){
                if(node2.ResNum == node1.ResNum+1){
                    if(node1.AtomType == "C" && node2.AtomType == "N"){
                        FP.Protein.AddEdge(node1.Value, node2.Value);
                        node1.AddNeighbor(node2);
                        node2.AddNeighbor(node1);
                        Vector3 start = new Vector3((float)node1.coordinates[0], (float)node1.coordinates[1], (float)node1.coordinates[2]);
                        Vector3 end = new Vector3((float)node2.coordinates[0], (float)node2.coordinates[1], (float)node2.coordinates[2]);
                        var offset = end - start;
                        var position = start + (offset/2.0f);
                        var newBond = Instantiate(Bond, position, Quaternion.identity);
                        newBond.transform.up = offset;
                    }
                }
                if(node2.ResNum == node1.ResNum && node1.Value != node2.Value){
                    foreach ((string, string) tup in Connections["backbone"]){
                        if((tup.Item1 == node1.AtomType && tup.Item2 == node2.AtomType) || (tup.Item1 == node2.AtomType && tup.Item2 == node1.AtomType)){
                        FP.Protein.AddEdge(node1.Value, node2.Value);
                        node1.AddNeighbor(node2);
                        node2.AddNeighbor(node1);
                        Vector3 start = new Vector3((float)node1.coordinates[0], (float)node1.coordinates[1], (float)node1.coordinates[2]);
                        Vector3 end = new Vector3((float)node2.coordinates[0], (float)node2.coordinates[1], (float)node2.coordinates[2]);
                        var offset = end - start;
                        var position = start + (offset/2.0f);
                        var newBond = Instantiate(Bond, position, Quaternion.identity);
                        newBond.transform.up = offset;
                            
                        }
                }
            }
            }

            foreach (var node2 in AllNodes){
                //List<(string, string)> Conn = new List<(string, string)>();
                if(node2.ResNum == node1.ResNum && node1.Value != node2.Value){
                    foreach ((string, string) tup in Connections[ResName]){
                        if((tup.Item1 == node1.AtomType && tup.Item2 == node2.AtomType) || (tup.Item1 == node2.AtomType && tup.Item2 == node1.AtomType)){
                        FP.Protein.AddEdge(node1.Value, node2.Value);
                        node1.AddNeighbor(node2);
                        node2.AddNeighbor(node1);
                        Vector3 start = new Vector3((float)node1.coordinates[0], (float)node1.coordinates[1], (float)node1.coordinates[2]);
                        Vector3 end = new Vector3((float)node2.coordinates[0], (float)node2.coordinates[1], (float)node2.coordinates[2]);
                        var offset = end - start;
                        var position = start + (offset/2.0f);
                        var newBond = Instantiate(Bond, position, Quaternion.identity);
                        newBond.transform.up = offset;
                            
                        }
                    }


                    
                    //Conn = Connections[ResName];



                }
            }

            

        }

        float Avgx = sumx/AllNodes.Count;
        float Avgy = sumy/AllNodes.Count;
        float Avgz = sumz/AllNodes.Count;



        GameObject.Find("CameraCenter").transform.position += new Vector3(Avgx, Avgy, Avgz);




    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
