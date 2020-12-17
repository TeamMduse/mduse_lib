using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_ColorB", MaterialPropertyFormat.Float4)]
    [GenerateAuthoringComponent]

    struct ColorBVector4Override : IComponentData
    {
        public float4 Value;
    }
}
