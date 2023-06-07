using UnityEngine;
using System.Collections.Generic;

public class TowerGenerator : MonoBehaviour
{
    
    [SerializeField] private TowerGenerationSettings _generationSettings;

    [Header("Tower transform")]

    [SerializeField] private Transform _tower;

    
    private void Start()
    {
        Generate(_generationSettings, _tower);       
    }

    private void Generate(TowerGenerationSettings generationSettingsSo, Transform tower)
    {

        List<Platform> spawnedPlatforms  = SpawnPlatforms(generationSettingsSo, out float offsetFromTop);

        FitTowerHeight(tower, offsetFromTop);

        spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
    }

    private List<Platform> SpawnPlatforms(TowerGenerationSettings generationSettingsSo, out float offsetFromTop)
    {
        
        var spawnedPlatforms = new List<Platform>(generationSettingsSo.PlatformVariantsCount + 2);

        offsetFromTop = generationSettingsSo.OffsetBetweenPlarforms;

        Platform startPlatform = Create(generationSettingsSo, generationSettingsSo.StartPlatformPrefab, ref offsetFromTop);
        spawnedPlatforms.Add(startPlatform);

        for (int i = 0; i < generationSettingsSo.PlatformVariantsCount; i++)
        {
            Platform platform = Create(generationSettingsSo, generationSettingsSo.PlatformVariantPrefab, ref offsetFromTop);
            spawnedPlatforms.Add(platform);
        }

        Platform finishPlatform = Create(generationSettingsSo, generationSettingsSo.FinishPlatformPrefab, ref offsetFromTop);
        spawnedPlatforms.Add(finishPlatform);

        return spawnedPlatforms;
    }


    private Vector3 getRandomYRotation(FloatRange rotationRange) => Vector3.up * rotationRange.Random;

    private Platform Create(TowerGenerationSettings generationSettingsSo, Platform platformPrefab, ref float offsetFromTop)
    {
        Platform createdPlatform = Instantiate(platformPrefab);
        Transform platformTransform = createdPlatform.transform;
        platformTransform.position = offsetFromTop * Vector3.down;
        platformTransform.eulerAngles = getRandomYRotation(generationSettingsSo.RotationRange);

        offsetFromTop += platformTransform.localScale.y + generationSettingsSo.OffsetBetweenPlarforms;

        return createdPlatform;
    }


    private void FitTowerHeight(Transform tower, float height)
    {
        Vector3 originalSize = tower.localScale;

        float towerHeight = height / 2.0f;

        tower.localScale = new Vector3(originalSize.x, towerHeight, originalSize.z);
        tower.localPosition -= Vector3.up * towerHeight;
    }
}
