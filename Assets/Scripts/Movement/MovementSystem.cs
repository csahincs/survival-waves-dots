using Enemy;
using Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Movement
{
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerComponent>();
            state.RequireForUpdate<MovementComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var playerPosition = new float3();
            foreach (var (transform, movement) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<MovementComponent>>()
                         .WithAll<PlayerComponent>())
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");
                var input = new float3(horizontal, 0, vertical);
            
                if (input.Equals(float3.zero))
                {
                    continue;
                }

                input = math.normalize(input) * movement.ValueRO.Speed * SystemAPI.Time.DeltaTime;
                transform.ValueRW.Position += input;
                playerPosition = transform.ValueRO.Position;
            }
            
            foreach (var (transform, movement) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<MovementComponent>>()
                         .WithAll<EnemyComponent>())
            {
                var direction = playerPosition - transform.ValueRO.Position;
                direction = math.normalize(direction) * movement.ValueRO.Speed * SystemAPI.Time.DeltaTime;
                transform.ValueRW.Position += direction;
            }
        }
    }
}
