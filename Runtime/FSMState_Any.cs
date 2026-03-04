using UnityEngine;
using System.Collections.Generic;

namespace FSMAI
{
    [CreateNodeMenu("Any Node"), NodeWidth(350), NodeTint("#21C2B5")]
    public class FSMState_Any : FSMStateBase
    {
        [Output(dynamicPortList = true)] public List<FSMTransition> transitions = new List<FSMTransition>();

        public virtual void OnUpdate(StateMachine machine)
        {
            //Execute transitions
            for (int i = 0; i < transitions.Count; i++)
            {
                FSMTransitionFork connectedFork = GetOutputPort("transitions " + i.ToString()).Connection.node as FSMTransitionFork;
                FSMStateBase returnedState = connectedFork.ForkResult(transitions[i].Decide(machine));

                if (returnedState is not FSMState_StayInCurrent)
                {
                    machine.ChangeState(returnedState as FSMState);
                    break;
                }
            }
        }

        private void Reset()
        {
            name = "ANY";
        }
    }
}