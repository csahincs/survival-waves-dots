using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Player.Movement
{
    public partial struct PlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerMovementComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var playerMovement = SystemAPI.GetSingleton<PlayerMovementComponent>();
            
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var input = new float3(horizontal, 0, vertical) * 
                        SystemAPI.Time.DeltaTime * playerMovement.Speed;
            
            if (input.Equals(float3.zero))
            {
                return;
            }
            
            foreach (var playerTransform in
                     SystemAPI.Query<RefRW<LocalTransform>>()
                         .WithAll<PlayerMovementComponent>())
            {
                var newPos = playerTransform.ValueRO.Position + input;
                playerTransform.ValueRW.Position = newPos;
            }
        }
    }
}
