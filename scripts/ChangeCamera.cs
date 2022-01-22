using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            SetCamera(1);
        } else
        {
            SetCamera(0);
        }
    }

    public void SetCamera(int camChange)
    {
        if (camChange == 0)
        {
            //aktifkan kamera utama
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        else 
        {
            //aktifkan kamera peta
            camera1.SetActive(false);
            camera2.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
