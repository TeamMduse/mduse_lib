using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Unity.Entities;


namespace MduseLib
{
    public class FilesLib : MonoBehaviour
    {

        public string fileTest;
        private List<AtomData> MolData = new List<AtomData>();

        private void Start()
        {

            string filePath = Path.Combine(Application.persistentDataPath, fileTest);

            Debug.Log("> " + filePath);

            readFile(filePath);

            
            drawAtoms();
        }

        // TEST

        private void drawAtoms() {

            CreatePrimitives prim = new CreatePrimitives();

            foreach (var item in MolData)
            {

                Vector3 pos = new Vector3(item.X,item.Y,item.Z);
                prim.CreatePrimitiveUnity(pos, Vector3.zero, Vector3.one, PrimitiveType.Sphere);
            }
        }


        public void readFile(string path)
        {

            using (StreamReader sr = File.OpenText(path))
            {
                string s = System.String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    //do what you have to here
                    print(s);

                    if (s.Contains("ATOM")) {
                        AtomData dato = new AtomData();

                        dato.NameID =  s.Substring(0, 6).Trim();
                        dato.AtomSerialNumber = int.Parse(s.Substring(6, 6));
                        dato.AtomName = s.Substring(12, 4).Trim(); 
                        dato.AlternateLocationIndicator = s.Substring(16, 1).Trim();
                        dato.ResidueName = s.Substring(17, 4).Trim();
                        dato.ChainIdentifier = s.Substring(21, 1).Trim();
                        dato.ResidueSequenceNumber = int.Parse(s.Substring(22, 4).Trim());
                        dato.CodeInsertionsResidues = s.Substring(26, 4).Trim();
                        dato.X = float.Parse(s.Substring(30, 8).Trim());
                        dato.Y = float.Parse(s.Substring(38, 8).Trim());
                        dato.Z = float.Parse(s.Substring(46, 8).Trim());
                        dato.Occupancy = float.Parse( s.Substring(54, 6).Trim());
                        dato.Temperature = float.Parse(s.Substring(60, 6).Trim());
                        dato.unknow = s.Substring(66, 6).Trim();
                        dato.SegmentIdentifier= s.Substring(72, 4).Trim();
                        dato.ElementSymbol = s.Substring(76, 2).Trim();
                        dato.Charge = s.Substring(78, 2).Trim();


                        MolData.Add(dato); // 


                    }


                    if (s.Contains("CONECT")) {

                        List<int> Bond = new List<int>();

                        int cuts = (s.Length - 6) / 5;

                        for (int i = 0; i < cuts; i++)
                        {
                            int cut = int.Parse(s.Substring((6 + i * 5),5));
                            Bond.Add(cut);
                        }
                         
                    }





                }
                 
            }




            //using (var reader = new BinaryReader(File.OpenRead("path")))
            //{
            //    var entry = new FileEntry
            //    {
            //        //Value1 = reader.ReadByte(),
            //        //Filename = reader.ReadChars(12), // would replace this with string
            //        //FileOffset = reader.ReadBytes(3),
            //        //whatever = reader.ReadDouble()
            //    };
            //}


        }

    }
 
    public class AtomData
    {
        public string NameID;
        public int AtomSerialNumber;
        public string AtomName;
        public string AlternateLocationIndicator;
        public string ResidueName;
        public string ChainIdentifier;
        public int ResidueSequenceNumber;
        public string CodeInsertionsResidues;
        public float X;
        public float Y;
        public float Z;
        public float Occupancy;
        public float Temperature;
        public string unknow;
        public string SegmentIdentifier;
        public string ElementSymbol;
        public string Charge;
          
    }
}