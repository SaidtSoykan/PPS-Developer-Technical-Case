using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //To be able to edit the walking speed from the editor
    public float walkSpeed;
    public float mouseSensitive;

    public GameObject cam;
    public GameObject caps;

    void Start()
    {
        
    }

    void Update()
    {
        playerMove();
        camMove();
    }
    void playerMove()
    {
        //got key input from user
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        //to fix the extra speed in the diagonal movement
        Vector3 way = Vector3.Normalize(new Vector3(-x, 0, z));
        //to move the player according to the key pressed
        transform.Translate(way * walkSpeed * Time.deltaTime);
    }
    void camMove()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        caps.transform.Rotate(new Vector3(0, 1, 0) * x * mouseSensitive);
        cam.transform.Rotate(new Vector3(-1, 0, 0) * y * mouseSensitive);
    }
}
