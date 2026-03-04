using UnityEngine;
using XNode;

namespace FSMAI
{
    public abstract class FSMNode : Node
    {
        protected override void Init() // OnEnable
        {
            base.Init();
        }

        public override object GetValue(NodePort port) // Return the value of an output port when requested
        {
            return null;
        }
    }
}