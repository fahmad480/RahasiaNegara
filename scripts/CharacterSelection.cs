using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterList;
    private int i;
    private int maxCharacter;

    void Start()
    {
        maxCharacter = characterList.Length;
        i = 0;
        showCharacter(i);
        Debug.Log("Jumlah Karakter: "+ maxCharacter);
    }

    public void nextCharacter()
    {
        if (i < maxCharacter-1)
        {
            i++;
            print("Selected character: " + i.ToString());
            showCharacter(i);
        }
    }

    public void previousCharacter()
    {
        if(i > 0)
        {
            i--;
            print("Selected character: " + i.ToString());
            showCharacter(i);
        }
    }

    private void showCharacter(int changeTo)
    {
        foreach (GameObject j in characterList)
        {
            j.SetActive(false);
        }
        characterList[changeTo].SetActive(true);
        PlayerPrefs.SetInt("choosedCharacter", changeTo);
    }
}
