using Unity.Burst;
using Unity.Entities;

namespace Player
{
    public partial struct PlayerSpawnerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerSpawnerComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            
            var player = SystemAPI.GetSingleton<PlayerSpawnerComponent>();
            state.EntityManager.Instantiate(player.Prefab);
        }
    }
}