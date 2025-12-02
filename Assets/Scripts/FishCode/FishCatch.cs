using UnityEngine;

public class FishCatch : MonoBehaviour
{
    public int fishScore = 5;

    void Start()
    {

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
