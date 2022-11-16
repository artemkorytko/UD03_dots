using Components;
using Unity.Entities;

namespace Systems
{
    [UpdateAfter(typeof(OnTriggerEnterSystem))]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class OnTriggerExitSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithAll<OnTriggerExitComponent>().ForEach((Entity entity) =>
            {
                em.RemoveComponent<OnTriggerExitComponent>(entity);
            }).WithStructuralChanges().Run();
        }
    }
}