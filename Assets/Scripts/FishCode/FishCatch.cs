using UnityEngine;

public class FishCatch : MonoBehaviour
{
    public int fishScore = 5;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

    }

    public void OnCollect()
    {
        //score logic
        Score.score += fishScore;
        //play sound

        //destroy object
        Destroy(gameObject);
    }   
}
