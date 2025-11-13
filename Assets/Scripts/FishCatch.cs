using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
//using UnityEngine.InputSystem;


public class FishCatch : MonoBehaviour
{
    public int fishScore = 5;
    
    ARRaycastManager raycastManager;
 
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //raycastManager = FindObjectOfType<ARRaycastManager>();
        raycastManager = FindFirstObjectByType<ARRaycastManager>();
    }


    //Won't Work

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit objHit;
                if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
                {
                    if (Physics.Raycast(ray, out objHit))
                    {
                        if (Physics.Raycast(ray, out objHit))
                        {

                            onCollect();

                        }
                    }
                }
            }
        }
    }

    public void onCollect()
    {
        //score logic
        Score.score += fishScore;
        //play sound

        //destroy object
        Destroy(gameObject);
    }

    void look()
    {
        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit objHit;
                if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
                {
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
        */
    }
}
