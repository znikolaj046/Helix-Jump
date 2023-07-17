using UnityEngine;

namespace Tower
{
    public class TowerRotation2 : MonoBehaviour
    {
        [SerializeField][Min(0.0f)] private float _rotationSpeed;
        public void Rotate2(float xAxis)
        {
            float Angle = xAxis * _rotationSpeed * Time.deltaTime;
        }
    }
}