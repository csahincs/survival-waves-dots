using Unity.Entities;

namespace Enemy.Spawner
{
    public struct EnemySpawnerComponent : IComponentData
    {
        public Entity Prefab;
        public float InnerCircleRadius;
        public float OuterCircleRadius;
        public float SpawnTime;
    }
}
