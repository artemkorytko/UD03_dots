using Unity.Entities;

namespace Components
{
    public struct TriggerComponent : IComponentData
    {
        public Entity Other;
    }
}