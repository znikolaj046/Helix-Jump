using UnityEngine;


public class Range<T> : ScriptableObject
{
    [Header("Platform Rotation")]
    [SerializeField][Min(0.0f)] private T _min;
    [SerializeField][Min(0.0f)] private T _max;

    public T Min => _min;
    public T Max => _max;
}