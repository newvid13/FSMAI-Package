using UnityEngine;
using XNode;

namespace FSMAI
{
    [CreateAssetMenu(menuName = "FSMAI/New AI Graph"), RequireNode(typeof(FSMState_Any), typeof(FSMState_Initial))]
    public class FSMGraph : NodeGraph
    {
        //
    }
}