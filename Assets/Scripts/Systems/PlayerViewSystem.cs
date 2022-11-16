using Components;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class PlayerViewSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.ForEach((Entity entity, ref PlayerViewComponent view) =>
            {
                var transform = em.GetComponentObject<Transform>(entity);
                transform.position = em.GetComponentData<Translation>(view.PlayerEntity).Value;
                transform.rotation = em.GetComponentData<Rotation>(view.PlayerEntity).Value;
            });
        }
    }
}