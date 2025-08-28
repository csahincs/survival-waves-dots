using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Enemy.Spawner
{
    public partial struct EnemySpawnerSystem : ISystem
    {
        private float _currentTimer;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemySpawnerComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var enemySpawner = SystemAPI.GetSingleton<EnemySpawnerComponent>();
            var random = new Random((uint)((SystemAPI.Time.ElapsedTime + 1) * 1000));

            _currentTimer += SystemAPI.Time.DeltaTime;

            if (!(_currentTimer >= enemySpawner.SpawnTime)) return;
            
            _currentTimer = 0;

            var enemyEntity = state.EntityManager.Instantiate(enemySpawner.Prefab);
            
            var angle = random.NextFloat(0, math.PI * 2f);
            var radius = math.sqrt(random.NextFloat(enemySpawner.InnerCircleRadius * enemySpawner.InnerCircleRadius, 
                enemySpawner.OuterCircleRadius * enemySpawner.OuterCircleRadius));
            var x = math.cos(angle) * radius;
            var z = math.sin(angle) * radius;
            
            state.EntityManager.SetComponentData(enemyEntity, LocalTransform.FromPosition(x, 0, z));
        }
    }
}
