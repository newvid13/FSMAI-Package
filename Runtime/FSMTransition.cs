using UnityEngine;

namespace FSMAI
{
    public abstract class FSMTransition : ScriptableObject
    {
        public const string createPath = "FSMAI/Transitions/";
        public abstract bool Decide(StateMachine machine);

    }
}