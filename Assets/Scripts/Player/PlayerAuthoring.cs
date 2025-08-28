using Player.Movement;
using Unity.Entities;
using UnityEngine;

namespace Player
{
    public class PlayerAuthoring : MonoBehaviour
    {
        public float Speed;
        
        public class PlayerBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent<PlayerComponent>(entity);
                AddComponent(entity, new PlayerMovementComponent()
                {
                    Speed = authoring.Speed,
                });
            }
        }
    }
}
