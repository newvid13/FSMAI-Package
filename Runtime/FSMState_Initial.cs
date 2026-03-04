using UnityEngine;

namespace FSMAI
{
    [CreateNodeMenu("Start Node"), NodeWidth(100), NodeTint("#4C9E61")]
    public class FSMState_Initial : FSMStateBase
    {
        [Output(backingValue = ShowBackingValue.Never)] public int exit;

        private void Reset()
        {
            name = "START";
        }
    }
}