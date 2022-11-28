using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public bool useOffsetValue;
    public float rotateSpeed;
    public Transform pivot;
    public float MaxAngle;
    public float MinAngle;
    public bool invertY;
    void Start()
    {
        if (useOffsetValue)
        {
            offset = target.transform.position - transform.position;
        }      
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }
    private void Update()
    {
        //Get position x,y of mouse and rotate target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        if (invertY)
        {
            pivot.transform.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.transform.Rotate(-vertical, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > MaxAngle && pivot.rotation.eulerAngles.x < 180f)
        { 
            pivot.rotation = Quaternion.Euler(MaxAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + MinAngle)
        {
            pivot.rotation = Quaternion.Euler(360 + MinAngle, 0, 0);
        }

        //Move the camera depending on the current camera angle and "Offset"
        float Xangle = pivot.transform.eulerAngles.x;
        float Yangle = target.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(Xangle, Yangle, 0);
        transform.position = target.transform.position - (rotation * offset);

        //Fix camera
        if(transform.position.y < target.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,target.transform.position.y ,transform.position.z);
        }

        transform.LookAt(target.transform);
    }
}
