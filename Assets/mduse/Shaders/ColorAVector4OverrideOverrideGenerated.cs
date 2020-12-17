using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_ColorA", MaterialPropertyFormat.Float4)]
    [GenerateAuthoringComponent]

    struct ColorAVector4Override : IComponentData
    {
        public float4 Value;
    }
}
