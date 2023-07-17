using Ball;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformPassTrigger :MonoBehaviour
{    

    private Platform _parentPlatform;
    private void Start()
    {
        _parentPlatform = GetComponentInParent<Platform>();
    }
    
    private void OnValidate() => GetComponent<Collider>().isTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BallCollision _) == false)
            return;

        _parentPlatform.UnhookAllParts();
        Destroy(gameObject);
    }
}
