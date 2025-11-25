using UnityEngine;

public class FishLineControl : MonoBehaviour
{
    public GameObject fishLineObject;
    public float ShowFLTime = 0.5f;
    float ShowFLCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishLineObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowFLCounter > 0)
        {
            ShowFLCounter -= Time.deltaTime;
            if (ShowFLCounter <= 0)
            {
                fishLineObject.SetActive(false);
            }
        }
    }

    public void ShowFishLine(float distance)
    {
        fishLineObject.SetActive(true);
        ShowFLCounter = ShowFLTime;
        Vector3 newScale = gameObject.transform.localScale;
        newScale.z = distance;
        gameObject.transform.localScale = newScale;
    }
}
