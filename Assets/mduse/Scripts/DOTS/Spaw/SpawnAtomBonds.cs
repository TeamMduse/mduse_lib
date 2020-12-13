using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnAtomBonds : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectPrefab;

    private Entity entityPrefab;
    private World defaultWorld;
    private EntityManager entityManager;


    void Start()
    {
        // Valores por defecto.
        defaultWorld = World.DefaultGameObjectInjectionWorld;
        entityManager = defaultWorld.EntityManager;


        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(defaultWorld, null);

        entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObjectPrefab, settings);


        InstantiateEntity(new float3(0.0f, 0.0f, 0.0f));

        MakeEntity();
    }


    private void InstantiateEntity(float3 position) {

        Entity myEntity = entityManager.Instantiate(entityPrefab);
        entityManager.SetComponentData(myEntity, new Translation
        {
            Value = position
        });
    }

    private void MakeEntity() {

    }

}
