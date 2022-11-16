using Components;
using Unity.Entities;

namespace Systems
{
    [UpdateAfter(typeof(TriggerSystem))]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class OnTriggerEnterSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithAll<TriggerComponent, OnTriggerEnterComponent>().WithNone<OnTriggerStayComponent>().ForEach((Entity entity, in TriggerComponent triggerComponent) =>
            {
                em.AddComponentData(entity, new OnTriggerStayComponent() {Other = triggerComponent.Other});
                em.RemoveComponent<OnTriggerEnterComponent>(entity);
            }).WithStructuralChanges().Run();

            Entities.WithAll<TriggerComponent>().WithNone<OnTriggerEnterComponent, OnTriggerStayComponent>().ForEach((Entity entity, in TriggerComponent triggerComponent) =>
            {
                em.AddComponentData(entity, new OnTriggerEnterComponent() {Other = triggerComponent.Other});
            }).WithStructuralChanges().Run();
        }
    }
}