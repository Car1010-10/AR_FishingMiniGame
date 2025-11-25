using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class FisherManPC : MonoBehaviour
{
    public float RayCastDistance = 50f;
    public GameObject fishingRod;
    public GameObject HookMarkerPrefab;
    public FishLineControl fishLineController;

    bool Fish = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
        Touchscreen screen = Touchscreen.current;
        if (screen != null)
        {
            if (screen.IsPressed())
            {
                OnFish(ScreenWorld.Instance.WorldLocation);
            }
        }
    }

    void OnFish(Vector3 location)
    {
        PerformRaycast();
    }

    void PerformRaycast()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(fishingRod.transform.position, fishingRod.transform.forward, out hit, RayCastDistance);
        if (hasHit)
        {
            Debug.Log("Found " + hit.collider.gameObject.name);

            fishLineController.ShowFishLine(hit.distance);
            Instantiate(HookMarkerPrefab, hit.point, Quaternion.Euler(hit.normal));

            FishCatch fc = hit.collider.gameObject.GetComponentInParent<FishCatch>();
            if (fc)
            {
                fc.OnCollect();
            }
        }
    }
}
