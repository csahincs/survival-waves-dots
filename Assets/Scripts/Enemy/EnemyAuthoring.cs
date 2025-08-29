using Movement;
using Unity.Entities;
using UnityEngine;

namespace Enemy
{
    public class EnemyAuthoring : MonoBehaviour
    {
        public float Speed;
        
        private class EnemyBaker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<EnemyComponent>(entity);
                AddComponent(entity, new MovementComponent()
                {
                    Speed = authoring.Speed,
                });
            }
        }
    }
}
