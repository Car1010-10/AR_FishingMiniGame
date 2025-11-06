using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn; // may want to make it an array if I want to include other fish types
    public ARPlaneManager arPlaneManager;
    List<ARPlane> detectedPlanes = new List<ARPlane>();


    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (arPlaneManager == null)
        {
            Debug.Log("No Plane assigned!!");
            return;
        }
        //ITrackablesChanged<ARPlane> OnPlanesChanged;
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlanesChanged(ARTrackablesChangedEventArgs<ARPlane> changes)
    {
        foreach (var plane in changes.added)
        {
            detectedPlanes.Add(plane);
        }

        foreach (var plane in changes.updated)
        {
            // handle updated planes
        }

        foreach (var plane in changes.removed)
        {
            // handle removed planes
        }
    }

    // Will eventually call this function to summon fishes, maybe through a timmer or button
    public void SpawnRandomObjectOnPlane()
    {
        if (detectedPlanes.Count == 0)
        {
            Debug.Log("No Planes detected");
            return;
        }

        // Chooses a random plane
        ARPlane randomPlane = detectedPlanes[Random.Range(0, detectedPlanes.Count)];

        // this right here may be subject to change
        Vector3 randomPosition = GetRandomPointonPlane(randomPlane);

        GameObject prefabToSpawn = objectToSpawn[Random.Range(0, objectToSpawn.Length)];

        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity); // if array added this might need to be changed
    }

    Vector3 GetRandomPointonPlane(ARPlane plane)
    {
        Vector3 center = plane.center;
        Vector3 extents = plane.extents;

        float randomX = Random.Range(-extents.x, extents.x);
        float randomZ = Random.Range(-extents.z, extents.z); // Using Z for the plane's depth

        // Convert local coordinates to world coordinates relative to the plane's transform
        Vector3 localRandomPoint = new Vector3(randomX, 0, randomZ);
        return plane.transform.TransformPoint(localRandomPoint);
    }



    /*
    void Update ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    // Get the first hit on a plane
                    Pose hitPose = hits[0].pose;

                    // Instantiate the object at the hit position and rotation
                    Instantiate(objectToSpawn, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
    */
}
