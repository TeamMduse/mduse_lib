using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using UnityEngine;

public class SpawnAtomBonds : MonoBehaviour
{
      
    [SerializeField] private GameObject gameObjectPrefab;

    private Entity entityPrefab;
    private World defaultWorld;
    private EntityManager entityManager;


    void Start()
    {
        // Default values.
        defaultWorld = World.DefaultGameObjectInjectionWorld;
        entityManager = defaultWorld.EntityManager;


        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(defaultWorld, null);

        entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObjectPrefab, settings);


        //InstatiateEntitiesCloud();


    }


    public void InstantiateEntity(float3 position) {

        Entity myEntity = entityManager.Instantiate(entityPrefab);
        entityManager.SetComponentData(myEntity, new Translation
        {
            Value = position
        });
    }

    private void InstatiateEntitiesCloud() {
        for (int i = 0; i < 100; i++)
        {

            float3 pos = new float3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
            InstantiateEntity(pos);

        }
    }


    private void MakeEntity() {

    }

}
