using UnityEngine;

namespace FSMAI
{
    [CreateNodeMenu("Transition Fork"), NodeWidth(150), NodeTint("#234A54")]
    public class FSMTransitionFork : FSMNode
    {
        [Input(backingValue = ShowBackingValue.Never)] public int entry;
        [Output] public FSMNode trueState;
        [Output] public FSMNode falseState;

        public FSMNode ForkResult(bool decisionResult)
        {
            FSMNode returnState = null;

            if (decisionResult && GetOutputPort("trueState").Connection != null)
                returnState = GetOutputPort("trueState").Connection.node as FSMNode;
            else if (!decisionResult && GetOutputPort("falseState").Connection != null)
                returnState = GetOutputPort("falseState").Connection.node as FSMNode;

            return returnState;
        }

        private void Reset()
        {
            name = "FORK";
        }
    }

}