using Z3.NodeGraph.Tasks;
using UnityEngine;
using Z3.NodeGraph.Core;
using UnityEngine.Animations.Rigging;

namespace Z3.NodeGraph.TaskPack.AnimationRigging
{
    [NodeCategory(Categories.AnimationRigging)]
    [NodeDescription("TODO")]
    public class SetMultiAimTarget : ActionTask // AimIK
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<MultiAimConstraint> data;
        [SerializeField] private Parameter<Transform> target;

        public override string Info => $"{base.Info} = {target}";

        protected override void StartAction()
        {
            //IKSolverAim ikAim = agent.GetIKSolver() as IKSolverAim;

            //ikAim.target = target.value;
            EndAction();
        }
    }
}