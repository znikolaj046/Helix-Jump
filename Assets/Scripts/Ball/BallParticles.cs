using UnityEngine;

public class BallParticles : MonoBehaviour
{
    private const float SurfaceYOffset = 0.06f;
    [SerializeField] private ParticleSystem _collisionParticlePrefab;
    [SerializeField] private ParticleSystem _collisionSpotPrefab;
    [SerializeField] private ParticleSystem _destroyParticlePrefab;
    private ParticleSystem _collisionParticles;

    private void Start()
    {
        _collisionParticles = Instantiate(_collisionParticlePrefab);
        _collisionSpotPrefab = Instantiate(_collisionSpotPrefab);
    }


    public void EmitCollisionParticles(Collision collision)
    {
        Vector3 collisionPosition = collision.contacts[0].point + Vector3.up * SurfaceYOffset;
        _collisionParticles.transform.position = collisionPosition;
        _collisionParticles.Play();
    }

    public void EmitSpotParticles(Collision collision)
    {
        Vector3 collisionPosition = collision.contacts[0].point + Vector3.up * SurfaceYOffset;
        _collisionSpotPrefab.transform.position = collisionPosition;
        _collisionSpotPrefab.Play();
    }

    public void EmitDestroyParticles(Vector3 position) => Instantiate(_destroyParticlePrefab, position, Quaternion.identity);
}
