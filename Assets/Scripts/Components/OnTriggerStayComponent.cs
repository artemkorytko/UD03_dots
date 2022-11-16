using Unity.Entities;

namespace Components
{
    public struct OnTriggerStayComponent : IComponentData
    {
        public Entity Other;
    }
}