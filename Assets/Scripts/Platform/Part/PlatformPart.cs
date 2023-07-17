using UnityEngine;

public abstract class PlatformPart : MonoBehaviour
{
    private const Transform WorldParent = null;
    public void UnhookByEjection(ExtensionSo extensionSo, Vector3 platformCenter)
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        transform.SetParent(WorldParent);

        rigidbody.detectCollisions = false;
        extensionSo.Pushout(rigidbody, platformCenter);
    }
}
