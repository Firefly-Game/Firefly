using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float sensitivity = 1;

        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        float scroll = Input.mouseScrollDelta.y;

        transform.RotateAround(transform.position, -Vector3.up, rotateHorizontal * sensitivity);
        transform.RotateAround(transform.position, transform.right, rotateVertical * sensitivity);


        transform.RotateAround(transform.position, transform.forward, scroll * sensitivity);
    }
}
