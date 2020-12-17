using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;


public class AtomSystem : SystemBase
{

    protected override void OnCreate()
    {
        base.OnCreate();


    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, in AtomData atom ) =>
        {
             

             

            

        }).Run();



    }
}
