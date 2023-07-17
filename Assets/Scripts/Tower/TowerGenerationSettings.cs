using System;
using System.Collections.Generic;
using UnityEngine;
using Extensions;


[CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]
public class TowerGenerationSettings : ScriptableObject
{
    [SerializeField][Min(0)] private int _platformVariantsCount;
    [SerializeField][Min(0.0f)] private float _offsetBetweenPlarforms;

    [SerializeField] private FloatRange _rotationRange;

    [Header("Platform Prefabs")]
    [SerializeField] private Platform _startPlatformPrefab;
    [SerializeField] private Platform _finishPlatformPrefab;
    [SerializeField] private Platform[] _platformVariantPrefabs = Array.Empty<Platform>();

    public Platform StartPlatformPrefab => _startPlatformPrefab;
    public Platform FinishPlatformPrefab => _finishPlatformPrefab;
    public Platform PlatformVariantPrefab => _platformVariantPrefabs.Random();

    public int PlatformVariantsCount => _platformVariantsCount;
    public float OffsetBetweenPlarforms => _offsetBetweenPlarforms;

    public FloatRange RotationRange => _rotationRange;
}
