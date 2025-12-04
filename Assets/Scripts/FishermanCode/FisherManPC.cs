using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class FisherManPC : MonoBehaviour
{
    public float RayCastDistance = 50f;
    public GameObject fishingRod;
    public GameObject HookMarkerPrefab;
    public FishLineControl fishLineController;

    public AudioClip Reel;
    AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //enable touch input
        Touchscreen screen = Touchscreen.current;
        if (screen != null)
        {
            if (screen.IsPressed())
            {
                source.PlayOneShot(Reel);
                PerformRaycast(); //ScreenWorld.Instance.WorldLocation
            }
        }
    }

    void OnFish() //Vector3 location
    {
        PerformRaycast();
    }

    void PerformRaycast()
    {
        //performs a raycast to fish and hit the fish prefab to add to your score
        RaycastHit hit;
        bool hasHit = Physics.Raycast(fishingRod.transform.position, fishingRod.transform.forward, out hit, RayCastDistance);
        if (hasHit)
        {
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
