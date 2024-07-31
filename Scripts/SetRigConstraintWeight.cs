using UnityEngine;
using UnityEngine.Animations.Rigging;
using Z3.NodeGraph.Tasks;
using Z3.NodeGraph.Core;

namespace Z3.NodeGraph.TaskPack.AnimationRigging
{
    [NodeCategory(Categories.AnimationRigging)]
    [NodeDescription("TODO")]
    public class SetRigConstraintWeight : ActionTask
    {
        public Parameter<IRigConstraint> rigConstraint;

        public bool useSpeed = true;
        //[MinMaxSlider(0f, 1f)]
        public Parameter<float> weight;
        //[ShowIf(nameof(useSpeed), 1)]
        public Parameter<float> duration;

        private float currentWeight;

        public override string Info => $"Set {rigConstraint} Weight = {weight}";

        protected override void StartAction()
        {

            if (useSpeed)
            {
                currentWeight = rigConstraint.Value.weight;
            }
            else
            {
                rigConstraint.Value.weight = weight.Value;
                EndAction();
            }
        }

        protected override void UpdateAction()
        {
            currentWeight = Mathf.MoveTowards(currentWeight, weight.Value, 1f / duration.Value * Time.fixedDeltaTime);
            rigConstraint.Value.weight = currentWeight;

            if (currentWeight == weight.Value)
            {
                EndAction();
            }
        }
    }
}