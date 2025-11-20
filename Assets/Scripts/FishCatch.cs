using UnityEngine;



public class FishCatch : MonoBehaviour
{
    public int fishScore = 5;

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }


    //Won't Work

    // Update is called once per frame
    void Update()
    {
    }

    public void onCollect()
    {
        //score logic
        Score.score += fishScore;
        //play sound

        //destroy object
        Destroy(gameObject);
    }

   
}
