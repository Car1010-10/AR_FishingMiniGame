using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;


public class FishRandomizerSpawn : MonoBehaviour
{
    public GameObject[] fishPrefabs; // Array of prefabs to spawn
    public ARPlaneManager arPlaneManager;
    private List<ARPlane> detectedPlanes = new List<ARPlane>();

    public float spawnInterval = 3f;
    float timer;

    Vector3 randomPosition;
    ARPlane randomPlane;

    void Start()
    {
        timer = spawnInterval;
        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager not assigned!");
            return;
        }
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomObjectOnPlane();
            timer = 0f;
        }
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane);
        }
        foreach (var plane in args.updated)
        {
            // You might want to update plane data here if needed
        }
        foreach (var plane in args.removed)
        {
            detectedPlanes.Remove(plane);
        }
    }

    // Call this function to spawn an object will be implemeneted in other ways
    public void SpawnRandomObjectOnPlane()
    {
        if (detectedPlanes.Count == 0)
        {
            Debug.LogWarning("No AR planes detected yet.");
            return;
        }

        // Choose a random plane
        randomPlane = detectedPlanes[Random.Range(0, detectedPlanes.Count)];

        // simple approach
        randomPosition = GetRandomPointOnPlane(randomPlane);

        // Choose a random prefab
        GameObject prefabToSpawn = fishPrefabs[Random.Range(0, fishPrefabs.Length)];

        // Instantiate the object
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }

    private Vector3 GetRandomPointOnPlane(ARPlane plane)
    {
        // Get the plane's center and extents
        Vector3 center = plane.center;
        Vector3 extents = plane.extents;

        // Generate random local coordinates within the plane's extents
        float randomX = Random.Range(-extents.x, extents.x);
        float randomZ = Random.Range(-extents.z, extents.z); // Using Z for the plane's depth

        // Convert local coordinates to world coordinates relative to the plane's transform
        Vector3 localRandomPoint = new Vector3(randomX, 0, randomZ);
        return plane.transform.TransformPoint(localRandomPoint);
    }
}
