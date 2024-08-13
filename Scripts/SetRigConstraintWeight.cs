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
        [SerializeField] private Parameter<IRigConstraint> rigConstraint;
        [SerializeField] private bool useSpeed = true;
        //[MinMaxSlider(0f, 1f)]
        [SerializeField] private Parameter<float> weight;
        //[ShowIf(nameof(useSpeed), 1)]
        [SerializeField] private Parameter<float> duration;

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
            currentWeight = Mathf.MoveTowards(currentWeight, weight.Value, 1f / duration.Value * DeltaTime);
            rigConstraint.Value.weight = currentWeight;

            if (currentWeight == weight.Value)
            {
                EndAction();
            }
        }
    }
}