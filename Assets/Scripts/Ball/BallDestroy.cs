using Cinemachine;
using UnityEngine;

namespace Ball
{
    public class BallDestroy : MonoBehaviour
    {
        [SerializeField] private Transform _ball;
        [SerializeField] private BallParticles _particles;
        [SerializeField] private CinemachineImpulseSource _impulseSource;

        public void Destroy()
        {
            _impulseSource.GenerateImpulse();
            _particles.EmitDestroyParticles(_ball.position);            
            Destroy(_ball.gameObject);
        }
    }
}
