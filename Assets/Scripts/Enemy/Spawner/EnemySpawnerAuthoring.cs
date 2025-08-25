using Unity.Entities;
using UnityEngine;

namespace Enemy.Spawner
{
    public class EnemySpawnerAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        public float InnerCircleRadius;
        public float OuterCircleRadius;
        public float SpawnTime;
        
        private class EnemySpawnerBaker : Baker<EnemySpawnerAuthoring>
        {
            public override void Bake(EnemySpawnerAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new EnemySpawnerComponent()
                {
                    Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                    InnerCircleRadius = authoring.InnerCircleRadius,
                    OuterCircleRadius = authoring.OuterCircleRadius,
                    SpawnTime = authoring.SpawnTime
                });
            }
        }
    }
}
