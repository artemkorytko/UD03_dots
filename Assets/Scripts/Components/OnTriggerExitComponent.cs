using Unity.Entities;

namespace Components
{
    public struct OnTriggerExitComponent : IComponentData
    {
        public Entity Other;
    }
}