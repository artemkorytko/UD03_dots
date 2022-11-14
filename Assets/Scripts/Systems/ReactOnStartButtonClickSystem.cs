using Components;
using Mono;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    [UpdateBefore(typeof(AddMoveComponentSystem))]
    public partial class ReactOnStartButtonClickSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            if (!GameManager.Instance.WasStartClick)
                return;
            var em = EntityManager;
            Entities.WithAny<PlayerComponent>().WithNone<MoveComponent>().ForEach((Entity entity) =>
            {
                em.AddComponent<NeedAddMoveComponent>(entity);
                
            }).WithStructuralChanges().Run();

            GameManager.Instance.WasStartClick = false;
        }
    }
}