using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public bool inAlt = false;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftAlt))
        //{
        //    if(inAlt == true)
        //    {
        //        inAlt = false;
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Cursor.visible = false;
        //    } else
        //    {
        //        inAlt = true;
        //        Cursor.lockState = CursorLockMode.None;
        //        Cursor.visible = true;
        //    }
        //}
    }
}
