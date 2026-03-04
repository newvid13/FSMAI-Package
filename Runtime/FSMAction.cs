using UnityEngine;

namespace FSMAI
{
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void Execute(StateMachine machine);
    }
}