using Components;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Systems
{
    [UpdateBefore(typeof(OnTriggerEnterSystem))]
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class TriggerSystem : SystemBase
    {
        private StepPhysicsWorld _step;
        private EndFixedStepSimulationEntityCommandBufferSystem _commandBuffer;

        protected override void OnCreate()
        {
            _step = World.GetOrCreateSystem<StepPhysicsWorld>();
            _commandBuffer = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        }

        private struct TriggerHandler : ITriggerEventsJob
        {
            public EntityCommandBuffer.ParallelWriter ParallelWriter;

            public void Execute(TriggerEvent triggerEvent)
            {
                var entity = triggerEvent.EntityA;
                var other = triggerEvent.EntityB;
                ParallelWriter.AddComponent(1, entity, new TriggerComponent() {Other = other});
                ParallelWriter.AddComponent(1, other, new TriggerComponent() {Other = entity});
            }
        }

        protected override void OnUpdate()
        {
            var triggerJob = new TriggerHandler() {ParallelWriter = _commandBuffer.CreateCommandBuffer().AsParallelWriter()};
            Dependency = triggerJob.Schedule(_step.Simulation, Dependency);
            _commandBuffer.AddJobHandleForProducer(Dependency);
        }
    }
}