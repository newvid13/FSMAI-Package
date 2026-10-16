using UnityEngine;

namespace FSMAI
{
    public abstract class FSMAction : ScriptableObject
    {
        public const string createPath = "FSMAI/Actions/";
        public abstract void Execute(StateMachine machine);
    }
}