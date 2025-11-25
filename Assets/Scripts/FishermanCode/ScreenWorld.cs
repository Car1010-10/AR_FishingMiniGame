using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenWorld : MonoBehaviour
{
    public static ScreenWorld Instance;
    public Camera cam;
    public Vector3 WorldLocation;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray direction = cam.ScreenPointToRay(GetScreenPoint());
        RaycastHit hit;
        if (Physics.Raycast(direction, out hit))
        {
            WorldLocation = hit.point;
        }
    }

    Vector2 GetScreenPoint()
    {
        Vector2 result = Vector2.zero;

        Touchscreen ts = Touchscreen.current;
        if (ts != null)
        {
            var touches = ts.touches;
            if (touches.Count > 0)
            {
                result = touches[0].position.ReadValue();
            }
        }

        return result;
    }
}
