using Unity.Entities;

namespace Player
{
    public struct PlayerSpawnerComponent : IComponentData
    {
        public Entity Prefab;
    }
}
