using UnityEngine;

public class HookLifetime : MonoBehaviour
{
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
