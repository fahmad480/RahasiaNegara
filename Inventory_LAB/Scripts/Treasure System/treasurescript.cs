using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasurescript : MonoBehaviour
{

    [SerializeField] bool isInteractable;
    [SerializeField] Animator anim;
    public TreasureContentUI treasureHUD;
    public Item[] collectable;
    
    private void Update()
    {
        bukaTreasure();
    }

    private void bukaTreasure()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(isInteractable)
            {
                anim.SetBool("open", true);
                treasureHUD.setTreasure(gameObject);
                if (isInteractable)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {   
        if(other.tag == "Player")
        {
            Debug.Log("harta karun ditemukan");
            isInteractable = true;
        }
        
    }

    private void OnTriggerExit()
    {
        isInteractable = false;
        anim.SetBool("open", false);
        treasureHUD.setTreasure(null);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
