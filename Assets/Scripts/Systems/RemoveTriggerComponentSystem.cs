using Components;
using Unity.Entities;

namespace Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class RemoveTriggerComponentSystem :SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithAll<TriggerComponent>().ForEach((Entity entity) =>
            {
                em.RemoveComponent<TriggerComponent>(entity);
            }).WithStructuralChanges().Run();
        }
    }
}