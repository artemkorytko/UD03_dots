using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct PlayerViewComponent : IComponentData
    {
        public Entity PlayerEntity;
    }
}