namespace Artemis.System
{
    #region Using statements

    using global::System;
    using global::System.Collections.Generic;

    #endregion Using statements

    /// <summary>Class DelayedEntityProcessingSystem.</summary>
    public abstract class DelayedEntityProcessingSystem : DelayedEntitySystem
    {
        /// <summary>Create a new DelayedEntityProcessingSystem. It requires at least one component.</summary>
        /// <param name="requiredType">The required component type.</param>
        /// <param name="otherTypes">Other component types.</param>
        protected DelayedEntityProcessingSystem(Type requiredType, params Type[] otherTypes)
            : base(GetMergedTypes(requiredType, otherTypes))
        {
        }

        /// <summary>Create a new DelayedEntityProcessingSystem. It requires an Aspect</summary>
        /// <param name="aspect">The aspect.</param>
        protected DelayedEntityProcessingSystem(Aspect aspect)
            : base(aspect)
        {
        }

        /// <summary>Process an entity this system is interested in.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="accumulatedDelta">The entity to process.</param>
        public abstract void Process(Entity entity, float accumulatedDelta);

        /// <summary>Process all entities with the delayed Entity processing system</summary>
        /// <param name="entities">Entities to process</param>
        /// <param name="accumulatedDelta">Total Delay</param>
        public override void ProcessEntities(IDictionary<int, Entity> entities, float accumulatedDelta)
        {
            foreach (Entity item in entities.Values)
            {
                this.Process(item, accumulatedDelta);
            }
        }
    }
}