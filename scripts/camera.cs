using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private float kecepatanRotasi = 100f;
    [SerializeField] private float mouseX, mouseY;
    public Transform player, target;
    private bool inAlt = false;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftAlt))
        //{
        //    if(inAlt == true)
        //    {
        //        inAlt = false;
        //        transform.position = new Vector3(0f, 0.43f, -14.33f);
        //        transform.rotation = Quaternion.Euler(3.629f, 180f, 0f);
        //    } else
        //    {
        //        inAlt = true;
        //        transform.position = new Vector3(0f, 0.43f, 14.33f);
        //        transform.rotation = Quaternion.Euler(3.629f, 0f, 0f);
        //    }
        //}
        if (!HudManager.GameIsPaused)
        {
            mouseX += Input.GetAxis("Mouse X") * kecepatanRotasi;
            mouseY -= Input.GetAxis("Mouse Y") * kecepatanRotasi;

            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.LookAt(target);

            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
