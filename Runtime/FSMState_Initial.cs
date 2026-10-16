using UnityEngine;

namespace FSMAI
{
    [NodeWidth(100), NodeTint("#4C9E61")]
    public class FSMState_Initial : FSMNode
    {
        [Output(backingValue = ShowBackingValue.Never)] public int exit;

        private void Reset()
        {
            name = "START";
        }
    }
}