using UnityEngine;

namespace FSMAI
{
    [CreateNodeMenu("Transition Fork"), NodeWidth(150), NodeTint("#234A54")]
    public class FSMTransitionFork : FSMNode
    {
        [Input(backingValue = ShowBackingValue.Never)] public int entry;
        [Output] public FSMStateBase trueState;
        [Output] public FSMStateBase falseState;

        public FSMStateBase ForkResult(bool decisionResult)
        {
            FSMStateBase returnState;

            if (decisionResult)
                returnState = GetOutputPort("trueState").Connection.node as FSMStateBase;
            else
                returnState = GetOutputPort("falseState").Connection.node as FSMStateBase;

            return returnState;
        }

        private void Reset()
        {
            name = "Fork";
        }
    }

}