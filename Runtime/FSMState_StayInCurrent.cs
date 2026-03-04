using UnityEngine;

namespace FSMAI
{
    [CreateNodeMenu("Stay In State"), NodeWidth(150), NodeTint("#F54927")]
    public class FSMState_StayInCurrent : FSMStateBase
    {
        [Input(backingValue = ShowBackingValue.Never)] public int entry;

        private void Reset()
        {
            name = "Stay In State";
        }
    }
}