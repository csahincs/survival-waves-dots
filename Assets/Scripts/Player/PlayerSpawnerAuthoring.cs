using Unity.Entities;
using UnityEngine;

namespace Player
{
    public class PlayerSpawnerAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        
        private class PlayerSpawnerBaker : Baker<PlayerSpawnerAuthoring>
        {
            public override void Bake(PlayerSpawnerAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerSpawnerComponent()
                {
                    Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                });
            }
        }
    }
}
