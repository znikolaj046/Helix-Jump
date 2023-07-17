using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField][Min(0.0f)] private float _rotationSpeed;
    [SerializeField][Min(0.0f)] private float _angularDrag;

    private Quaternion _newRotationAngle;

    private void Update()
    {
        CalculateRotation(Time.deltaTime * _rotationSpeed);
    }

    private void CalculateRotation(float rotationSpeed) => transform.rotation = Quaternion.Slerp(transform.rotation, _newRotationAngle, rotationSpeed);

    public void AddRotation(float xAxis)
    {
        Vector3 newEulerRotationAngle = transform.eulerAngles + Vector3.up * xAxis * -1;
        _newRotationAngle = Quaternion.Euler(newEulerRotationAngle);
    }
}
