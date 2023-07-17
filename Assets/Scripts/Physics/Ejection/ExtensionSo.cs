using UnityEngine;

[CreateAssetMenu(fileName = "ExtensionSo", menuName = "ScriptableObjects/Physics/Ejection")]
public class ExtensionSo : ScriptableObject
{

    [SerializeField][Min(0.0f)] private float _horizontalPlaneForce;
    [SerializeField][Min(0.0f)] private float _upForceModifier;
    public void Pushout(Rigidbody rigidbody, Vector3 position)
    {
        Vector3 forceDirection = rigidbody.worldCenterOfMass.normalized - position;
        Vector3 force = ScaleForce(forceDirection);

        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }

    private Vector3 ScaleForce(Vector3 forceDirection) => Vector3.Scale(forceDirection, new Vector3(_horizontalPlaneForce, 1, _upForceModifier)) + Vector3.up * _upForceModifier;
}
