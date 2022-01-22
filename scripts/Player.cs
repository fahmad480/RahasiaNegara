using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public GameObject[] characterList;
    int choosedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        

        if (SceneLoader.loadStatus)
        {
            LoadPlayer();
        }
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        EnviroSky.instance.SetTime(1, 1, data.time[0], data.time[1], data.time[2]);
        transform.position = position;
    }


}
