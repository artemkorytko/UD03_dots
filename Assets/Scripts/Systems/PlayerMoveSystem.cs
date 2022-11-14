using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    [UpdateAfter(typeof(AddMoveComponentSystem))]
    public partial class PlayerMoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var dt = Time.DeltaTime;

            Entities.WithAny<MoveComponent>().ForEach((ref Translation translation, in PlayerComponent playerComponent) =>
            {
                translation.Value += new float3(0, 0, playerComponent.Speed * dt);
            }).ScheduleParallel();
        }
    }
}