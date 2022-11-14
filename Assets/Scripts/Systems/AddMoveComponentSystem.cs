using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public partial class AddMoveComponentSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var em = EntityManager;
            Entities.WithNone<MoveComponent>().WithAll<PlayerComponent, NeedAddMoveComponent>().ForEach((Entity entity) =>
            {
                
                em.AddComponent<MoveComponent>(entity);
                em.RemoveComponent<NeedAddMoveComponent>(entity);
            }).WithStructuralChanges().Run();
        }
    }
}