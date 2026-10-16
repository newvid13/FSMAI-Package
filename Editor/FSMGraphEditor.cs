using XNodeEditor;
using System;

namespace FSMAI.Editor
{
    [CustomNodeGraphEditor(typeof(FSMGraph))]
    public class FSMGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (typeof(FSMState).IsAssignableFrom(type) || typeof(FSMTransitionFork).IsAssignableFrom(type))
            {
                return base.GetNodeMenuName(type);
            }
            else return null;
        }
    }
}