using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float playerHealth = 100f;
    public float armorHealth = 0f;
    public string info;

    float TimeAmount = 3;
    float currentTime;
    public bool particleStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100f;
        currentTime = TimeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > 100)
        {
            playerHealth = 100f;
        }
        healthParticle();
        SoundManager.PlaySound("");
    }

    public void healthParticle()
    {
        if (particleStatus)
        {
            currentTime -= Time.deltaTime;
            GameObject.Find("HealthRegen").GetComponent<ParticleSystem>().enableEmission = true;
            Debug.Log("healthPartcile on");
            if (currentTime <= 0)
            {
                Debug.Log("healthPartcile off");
                GameObject.Find("HealthRegen").GetComponent<ParticleSystem>().enableEmission = false;
                particleStatus = false;
                currentTime = TimeAmount;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if(armorHealth >= 10)
            {
                playerHealth -= 10;
                armorHealth -= 10;
            } else
            {
                playerHealth -= 20f;
            }
            info = "You can't go to isekai using mushroom u d*mb as*";
        }

        if (other.tag == "Enemy")
        {
            if (armorHealth >= 5)
            {
                playerHealth -= 5;
                armorHealth -= 5;
            }
            else
            {
                playerHealth -= 10f;
            }
            info = "You know u'r MC right? Why u died?";
        }

        if (other.tag == "Fire")
        {
            if (armorHealth >= 10)
            {
                playerHealth -= 5;
                armorHealth -= 5;
            }
            else
            {
                playerHealth -= 10f;
            }
            info = "I know u'r hungry, but don't burn yourself";
        }
    }
}
