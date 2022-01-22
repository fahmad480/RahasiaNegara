using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedCharacter : MonoBehaviour
{
    public GameObject[] characterList;

    // Start is called before the first frame update
    void Start()
    {
        int choosedCharacter = (PlayerPrefs.GetInt("choosedCharacter") == null) ? 0 : PlayerPrefs.GetInt("choosedCharacter");
        print("Current character: " + choosedCharacter);

        foreach (GameObject j in characterList)
        {
            j.SetActive(false);
        }

        characterList[choosedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
