using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject treePrefab;
    public GameObject cartPrefab;
    public GameObject rockPrefab;
    public GameObject mushroomPrefab;

    [Header("Settings")]
    public int mushroomCount = 99;
    public int environmentDensity = 50;
    public float mapSize = 20f;

    [Header("Generation Tweaks")]
    public float yOffset = -0.12f;
    public float maxTilt = 5f;

    [Header("Parents")]
    public Transform treesParent;
    public Transform cartsParent;
    public Transform rocksParent;
    public Transform mushroomsParent;

    [ContextMenu("Generate Map")]
    public void Generate()
    {
        ClearMap();

        // 1. Spawn Exactly Mushrooms
        for (int i = 0; i < mushroomCount; i++)
        {
            SpawnObject(mushroomPrefab, mushroomsParent);
        }

        // 2. Spawn Random Environment
        for (int i = 0; i < environmentDensity; i++)
        {
            int rand = Random.Range(0, 3);
            GameObject prefab = null;
            Transform parent = null;

            if (rand == 0) { prefab = treePrefab; parent = treesParent; }
            else if (rand == 1) { prefab = cartPrefab; parent = cartsParent; }
            else { prefab = rockPrefab; parent = rocksParent; }

            if (prefab != null) SpawnObject(prefab, parent);
        }
        
        Debug.Log("Map Generated with " + mushroomCount + " mushrooms!");
    }

    public void ClearMap()
    {
        ClearChildren(treesParent);
        ClearChildren(cartsParent);
        ClearChildren(rocksParent);
        ClearChildren(mushroomsParent);
    }

    private void ClearChildren(Transform parent)
    {
        if (parent == null) return;
        var children = new List<GameObject>();
        foreach (Transform child in parent) children.Add(child.gameObject);
        children.ForEach(child => DestroyImmediate(child));
    }

    private void SpawnObject(GameObject prefab, Transform parent)
    {
        if (prefab == null) return;

        float halfSize = mapSize / 2f;
        Vector3 pos = new Vector3(
            Random.Range(-halfSize, halfSize),
            yOffset,
            Random.Range(-halfSize, halfSize)
        );

        GameObject obj = Instantiate(prefab, pos, Quaternion.identity, parent);
        
        // Random tilt relative to the -90 X baseline
        float tiltX = -90f + Random.Range(-maxTilt, maxTilt);
        float tiltZ = Random.Range(-maxTilt, maxTilt);
        obj.transform.eulerAngles = new Vector3(tiltX, Random.Range(0, 360), tiltZ);
        
        // Random variance in scale for natural look
        float scaleVar = Random.Range(0.8f, 1.2f);
        obj.transform.localScale *= scaleVar;
    }
}
