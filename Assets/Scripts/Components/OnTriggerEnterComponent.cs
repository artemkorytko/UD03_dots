using Unity.Entities;

namespace Components
{
    public struct OnTriggerEnterComponent : IComponentData
    {
        public Entity Other;
    }
}