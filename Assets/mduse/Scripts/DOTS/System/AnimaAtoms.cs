using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


// TODO :Esto tiene que ser multitarea
public class AnimaAtoms : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans) =>
        {
             
        });
  }
}
