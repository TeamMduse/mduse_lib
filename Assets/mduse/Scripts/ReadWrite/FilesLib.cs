using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;

namespace MduseLib
{
    public class FilesLib : MonoBehaviour
    {

        public string fileTest;
        private List<AtomInfo> MolData = new List<AtomInfo>();
        private List<BondInfo> BondData = new List<BondInfo>();
        private int[] listID;


        [SerializeField] private SpawnAtomBonds spaw;

        // DOTS
        [SerializeField] private GameObject SpherePrefab;
        [SerializeField] private GameObject BondPrefab;

        private Entity entityPrefabSphere;
        private Entity entityPrefabBond;
        private World defaultWorld;
        private EntityManager entityManager;
        private Convert cnv;




        private void Start()
        {
            // Default values.
            defaultWorld = World.DefaultGameObjectInjectionWorld;
            entityManager = defaultWorld.EntityManager;

            // CONVERSION
            GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(defaultWorld, null);

            entityPrefabSphere = GameObjectConversionUtility.ConvertGameObjectHierarchy(SpherePrefab, settings);
            entityPrefabBond = GameObjectConversionUtility.ConvertGameObjectHierarchy(BondPrefab, settings);


            cnv = new Convert();

            //string filePath = Path.Combine(Application.persistentDataPath, fileTest);
            string filePath = Path.Combine(Application.streamingAssetsPath, fileTest);

            Debug.Log("> " + filePath);

            readFile(filePath);


            drawAtoms();

            drawBonds();
        }

        // TEST


        private void drawAtoms()
        {


            foreach (var item in MolData)
            {
                float3 pos = new float3(item.X, item.Y, item.Z);
                int3 atomCol = cnv.GetColor(item.AtomName.ToUpper());

                //print(item.AtomName.ToUpper() + " " + atomCol);
                InstantiateEntitySphere(pos, atomCol);
            }
        }

        private void drawBonds()
        {


            foreach (var item in BondData)
            {

                float3 pos2 = new float3(0f, 0f, 0f);
                int3 atomCol2 = new int3(0, 0, 0);

                //Debug.Log(item.bondID[0]);

                int indx = listID[item.bondID[0]];
                float3 pos1 = new float3(MolData[indx].X, MolData[indx].Y, MolData[indx].Z);

                int3 atomCol1 = cnv.GetColor(MolData[indx].AtomName.ToUpper());

                for (int i = 1; i < item.bondID.Count; i++)
                {
                    indx = listID[item.bondID[i]]; ;

                    if (indx < MolData.Count && indx>=0)
                    {
                        pos2 = new float3(MolData[indx].X, MolData[indx].Y, MolData[indx].Z);

                        atomCol2 = cnv.GetColor(MolData[indx].AtomName.ToUpper());

                        InstantiateEntityBond(pos1, pos2, atomCol1, atomCol2);
                    }

                }

            }
        }


        public void InstantiateEntitySphere(float3 position, int3 color)
        {

            Entity myEntity = entityManager.Instantiate(entityPrefabSphere);
            entityManager.SetComponentData(myEntity, new Translation
            {
                Value = position
            });

            entityManager.AddComponentData(myEntity, new ScalePivot { Value = new float3(0, 0, 0) });

            entityManager.AddComponentData(myEntity, new NonUniformScale { Value = new float3(0.5f, 0.5f,0.5f) });


            entityManager.SetComponentData(myEntity, new AtomData
            {
                pos = position,
                color = color

            });

            entityManager.SetComponentData(myEntity, new ColorAtomVector4Override
            {
                Value = new float4(color.x, color.y, color.z, 255.0f)
            });
        }


        public void InstantiateEntityBond(float3 pos1, float3 pos2, int3 color1, int3 color2)
        {

            Entity myEntity = entityManager.Instantiate(entityPrefabBond);


            entityManager.AddComponentData(myEntity, new ScalePivot { Value = new float3(0, 0, 0) });

            entityManager.AddComponentData(myEntity, new NonUniformScale { Value = new float3(0.25f, 0.25f, math.distance(pos1, pos2)/2.0f) });


            entityManager.SetComponentData(myEntity, new Translation
            {
                Value = pos1
            });

        



            entityManager.SetComponentData(myEntity, new Rotation
            {
                Value = quaternion.LookRotationSafe(pos2 - pos1, math.up())
            });

         
            entityManager.SetComponentData(myEntity, new BondData
            {
                pos1 = pos1,
                pos2 = pos2,
                color1 = color1,
                color2 = color2
            });

            entityManager.SetComponentData(myEntity, new ColorAVector4Override
            {
                Value = new float4(color1.x, color1.y, color1.z, 255.0f)
            });

            entityManager.SetComponentData(myEntity, new ColorBVector4Override
            {
                Value = new float4(color2.x, color2.y, color2.z, 255.0f)
            });
        }


        public void readFile(string path)
        {

            using (StreamReader sr = File.OpenText(path))
            {
                string s = System.String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    //do what you have to here
                    //print(s);

                    if (s.Contains("ATOM"))
                    {
                        AtomInfo dato = new AtomInfo();

                        dato.NameID = s.Substring(0, 6).Trim();
                        dato.AtomSerialNumber = int.Parse(s.Substring(6, 6));
                        dato.AtomName = s.Substring(12, 4).Trim();
                        dato.AlternateLocationIndicator = s.Substring(16, 1).Trim();
                        dato.ResidueName = s.Substring(17, 4).Trim();
                        dato.ChainIdentifier = s.Substring(21, 1).Trim();
                        dato.ResidueSequenceNumber = int.Parse(s.Substring(22, 4).Trim());
                        dato.CodeInsertionsResidues = s.Substring(26, 4).Trim();
                        dato.X = cnv.Str2Float(s.Substring(30, 8).Trim());
                        dato.Y = cnv.Str2Float(s.Substring(38, 8).Trim());
                        dato.Z = cnv.Str2Float(s.Substring(46, 8).Trim());
                        dato.Occupancy = cnv.Str2Float(s.Substring(54, 6).Trim());
                        dato.Temperature = cnv.Str2Float(s.Substring(60, 6).Trim());
                        dato.unknow = s.Substring(66, 6).Trim();
                        dato.SegmentIdentifier = s.Substring(72, 4).Trim();
                        dato.ElementSymbol = s.Substring(76, 2).Trim();
                        dato.Charge = s.Substring(78, 2).Trim();

                        //Debug.Log(dato.AtomName);

                        MolData.Add(dato); //
                        dato = null;
                         

                    }
                    

                    if (s.Contains("CONECT"))
                    {
                        //Debug.Log(s);
                        BondInfo Bond = new BondInfo();

                        int cuts = (s.Length - 6) / 5;

                        for (int i = 0; i < cuts; i++)
                        {
                            int cut = int.Parse(s.Substring((6 + i * 5), 5));
                            Bond.bondID.Add(cut);
                            //Debug.Log(cut);
                        }

                        BondData.Add(Bond);


                    }
                }

                // lista ordenada para los bonds
                listID = new int[MolData.Count + 1];
                int n = 0;
                foreach (var item in MolData)
                {
                    listID[item.AtomSerialNumber] = n;
                    n++;
                }

                sr.Dispose();
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

    public class AtomInfo
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


    public class BondInfo
    {
        public int AtomID;
        public List<int> bondID = new List<int>();

    }


    [Serializable]
    public struct ListColoredGameObjects
    {
        public string color;
        public GameObject prefab;
    }
}