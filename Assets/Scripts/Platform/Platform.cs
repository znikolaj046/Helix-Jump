using UnityEngine;
public class Platform : MonoBehaviour
{
    [SerializeField] private ExtensionSo extensionSo;

    private PlatformPart[] _parts;
    private void Start() => _parts = GetComponentsInChildren<PlatformPart>();

    public void UnhookAllParts()
    {
        foreach(PlatformPart platform in _parts)
        {
            platform.UnhookByEjection(extensionSo, transform.position);
            Destroy(platform, 2.0f);
        }
    }

}
