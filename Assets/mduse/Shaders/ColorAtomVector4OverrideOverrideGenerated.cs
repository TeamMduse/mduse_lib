using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_ColorAtom", MaterialPropertyFormat.Float4)]
    [GenerateAuthoringComponent]
    public struct ColorAtomVector4Override : IComponentData
    {
        public float4 Value;
    }
}
