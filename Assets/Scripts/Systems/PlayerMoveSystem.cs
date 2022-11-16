using Components;
using Mono;
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
            if (!GameManager.Instance.IsHasDirection)
                return;

            var dt = Time.DeltaTime;
            var y = GameManager.Instance.Direction.y;
            var x = GameManager.Instance.Direction.x;
            var mag = GameManager.Instance.DirectionMagnitude;
            var dir = new float3(x, 0f, y);
            Entities.WithAny<MoveComponent>().ForEach((ref Translation translation, ref Rotation rotation, in PlayerComponent playerComponent, in LocalToWorld ltw) =>
            {
                rotation.Value = math.slerp(ltw.Rotation, quaternion.LookRotation(dir, new float3(0, 1f, 0)), dt * playerComponent.RotationSpeed * mag);
                translation.Value += ltw.Forward * playerComponent.MoveSpeed * mag * dt;
            }).ScheduleParallel();
        }
    }
}