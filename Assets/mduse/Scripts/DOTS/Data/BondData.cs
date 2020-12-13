using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


[GenerateAuthoringComponent] // para poder añadirlo a un prefab
public struct BondData : IComponentData
{

    public float3 pos1;     // posicion al atomo1
    public float3 pos2;     // posicion al atomo2
    public float3 color1;   // color del atomo1
    public float3 color2;   // color del atomo2
     
}
