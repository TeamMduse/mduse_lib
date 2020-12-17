using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;


[GenerateAuthoringComponent] // para poder añadirlo a un prefab
public struct AtomData : IComponentData
{
     
    public float3 pos;     // posicion atomo
    public float3 color;   // color de atomo
 
}
