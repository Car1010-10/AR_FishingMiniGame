using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;


public class FishCatch : MonoBehaviour
{
    ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //raycastManager = FindObjectOfType<ARRaycastManager>();
        raycastManager = FindFirstObjectByType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray  = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit objHit;
                if (Physics.Raycast(ray, out objHit))
                {
                    if (objHit.collider.gameObject == this.gameObject)
                    {
                        onCollect();
                    }
                }
            }
        }
    }

    public void onCollect()
    {
        Debug.Log("Collected");
        //score logic
        //play sound
        Destroy(gameObject);
    }
}
