using System.Collections.Generic;
using UnityEngine;
using Graphs;

public class AADefinitions{

        public AADefinitions(){
        }


        static List<(string, string)> backbone = new List<(string, string)>
        {
            ("N", "CA"),
            ("CA", "C"),
            ("C", "O")
        };
        
        static List<(string, string)> Ala = new List<(string, string)>
        {
            ("CA", "CB")
        };

        static List<(string, string)> Arg = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD"),
            ("CD", "NE"),
            ("NE", "CZ"),
            ("CZ", "NH1"),
            ("CZ", "NH2")
        };

        static List<(string, string)> Asn = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "OD1"),
            ("CG", "ND1")
        };

        static List<(string, string)> Asp = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "OD1"),
            ("CG", "OD2")
        };

        static List<(string, string)> Cys = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "SG")
        };


        static List<(string, string)> Glu = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD"),
            ("CD", "OE1"),
            ("CD", "OE2")

        };

        static List<(string, string)> Gln = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD"),
            ("CD", "OE1"),
            ("CD", "NE2")
        };

        static List<(string, string)> Gly = new List<(string, string)>
        {

        };

        static List<(string, string)> His = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "ND1"),
            ("CG", "CD2"),
            ("ND1", "CE1"),
            ("CD2", "NE1"),
            ("CE1", "NE2"),
        };

        static List<(string, string)> HydPro = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "OD"),
            ("CG", "CD"),
            ("CD", "N")
        };

        static List<(string, string)> Ile = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG1"),
            ("CG1", "CD1"),
            ("CB", "CG2"),
        };

        static List<(string, string)> Leu = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD1"),
            ("CG", "CD2"),
        };

        static List<(string, string)> Lys = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD"),
            ("CD", "CE"),
            ("CE", "NZ")
        };

        static List<(string, string)> Met = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "SD"),
            ("SD", "CD"),
        };


        static List<(string, string)> Phe = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD1"),
            ("CG", "CD2"),
            ("CD1", "CE1"),
            ("CD2", "CE2"),
            ("CE1", "Z"),
            ("CE2", "Z")
        };

        static List<(string, string)> Pro = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD"),
            ("CD", "N")
        };

        static List<(string, string)> Ser = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "OG"),

        };

        static List<(string, string)> Thr = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "OG1"),
            ("CB", "CG2"),
        };

        static List<(string, string)> Trp = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD1"),
            ("CD1", "NE1"),
            ("NE1", "CE2"),
            ("CE2", "CZ2"),
            ("CZ2", "CH2"),
            ("CH2", "CZ3"),
            ("CZ3", "CE3"),
            ("CD3", "CD2"),
            ("CD2", "CG")
        };

        static List<(string, string)> Tyr = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG"),
            ("CG", "CD1"),
            ("CD1", "CE1"),
            ("CE1", "CZ"),
            ("CZ", "OH"),
            ("CZ", "CE2"),
            ("CE2", "CD2"),
            ("CD2", "CG"),
        };
        
        static List<(string, string)> Val = new List<(string, string)>
        {
            ("CA", "CB"),
            ("CB", "CG1"),
            ("CB", "CG2"),
        };

        public Dictionary<string, List<(string, string)>> ConnectionsList = new Dictionary<string, List<(string, string)>>{
            ["backbone"] = backbone,
            ["ALA"] = Ala,
            ["ARG"] = Arg,
            ["ASN"] = Asn,
            ["ASP"] = Asp,
            ["CYS"] = Cys,
            ["GLU"] = Glu,
            ["GLN"] = Gln,
            ["GLY"] = Gly,
            ["HIS"] = His,
            ["HPRO"] = HydPro,
            ["ILE"] = Ile,
            ["LEU"] = Leu,
            ["LYS"] = Lys,
            ["MET"] = Met,
            ["PHE"] = Phe,
            ["PRO"] = Pro,
            ["SER"] = Ser,
            ["THR"] = Thr,
            ["TYR"] = Tyr,
            ["TRP"] = Trp,
            ["VAL"] = Val

        };     

}