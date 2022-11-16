using Components;
using Unity.Entities;

namespace Systems
{
    public partial class OnPlayerEnterTriggerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithAll<PlayerComponent, OnTriggerEnterComponent>().ForEach((in OnTriggerEnterComponent component) =>
            {
                em.DestroyEntity(component.Other);
            }).WithStructuralChanges().Run();
        }
    }
}