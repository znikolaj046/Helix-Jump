using UnityEngine;

namespace Physics
{
    public class Bounce
    {
        private readonly Rigidbody _rigidBody;
        private readonly BounceData _bounceData;

        public Bounce(Rigidbody rigidBody, BounceData bounceData)
        {
            _rigidBody = rigidBody;
            _bounceData = bounceData;
        }

        public void BounceOff(Vector3 direction) => _rigidBody.AddForce(direction * _bounceData.Force, ForceMode.VelocityChange);

        public void ClampHeight()
        {
            Vector3 velocity = _rigidBody.velocity;
            velocity = velocity.y >= 0.0f ? Vector3.ClampMagnitude(velocity, _bounceData.MaxHeight) : velocity;
        }
    }
}