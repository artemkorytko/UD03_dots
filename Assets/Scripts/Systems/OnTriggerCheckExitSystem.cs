using Components;
using Unity.Entities;

namespace Systems
{
    [UpdateAfter(typeof(OnTriggerExitSystem))]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class OnTriggerCheckExitSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithAny<OnTriggerEnterComponent, OnTriggerStayComponent>().WithNone<TriggerComponent>().ForEach((Entity entity) =>
            {
                if (em.HasComponent<OnTriggerEnterComponent>(entity))
                {
                    em.AddComponentData(entity, new OnTriggerExitComponent() {Other = em.GetComponentData<OnTriggerEnterComponent>(entity).Other});
                    em.RemoveComponent<OnTriggerExitComponent>(entity);
                }

                if (em.HasComponent<OnTriggerStayComponent>(entity))
                {
                    em.AddComponentData(entity, new OnTriggerStayComponent() {Other = em.GetComponentData<OnTriggerStayComponent>(entity).Other});
                    em.RemoveComponent<OnTriggerStayComponent>(entity);
                }
            }).WithStructuralChanges().Run();
        }
    }
}