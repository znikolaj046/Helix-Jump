using UnityEngine;
namespace Structures
{
    [System.Serializable]
    public class Vector3Curves
    {
        [SerializeField] private AnimationCurve xCurve;
        [SerializeField] private AnimationCurve yCurve;
        [SerializeField] private AnimationCurve zCurve;

        public AnimationCurve XCurve => xCurve;
        public AnimationCurve YCurve => yCurve;
        public AnimationCurve ZCurve => zCurve;
    }
}