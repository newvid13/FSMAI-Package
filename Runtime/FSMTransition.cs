using UnityEngine;

namespace FSMAI
{
    public abstract class FSMTransition : ScriptableObject
    {
        public abstract bool Decide(StateMachine machine);

    }
}