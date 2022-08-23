using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float mouseSensitive;
    public float jumpPower;
    private float camAngle;

    public GameObject cam;
    public GameObject caps;
    void Update()
    {
        playerMove();
        camMove();
        if(Input.GetKeyDown("h"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if(Input.GetKeyDown("l"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void playerMove()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        Vector3 way = Vector3.Normalize(new Vector3(z, 0, x));
        transform.Translate(way * walkSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && caps.transform.position.y < 2)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        }
    }
    void camMove()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        caps.transform.Rotate(new Vector3(0, 1, 0) * x * mouseSensitive);
        camAngle -= y;
        camAngle = Mathf.Clamp(camAngle, -90, 90);
        cam.transform.localEulerAngles = new Vector3(camAngle, 0, 0);
    }
}
