using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Point")
        {
            player.GetComponent<Player>().score += 1;
            //other.GetComponent<AudioSource>().Play();
        }

        if (gameObject.tag == "HealthRegen")
        {
            player.GetComponent<HealthSystem>().playerHealth = 100f;
            //other.GetComponent<AudioSource>().Play();
        }

        if (player)
        {
            Destroy(gameObject);
        }
    }
}
