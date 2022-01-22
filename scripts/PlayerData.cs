using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int[] time;
    public int choosedCharacter;

    public PlayerData(Player player)
    {
        choosedCharacter = PlayerPrefs.GetInt("choosedCharacter");
        time = new int[3];
        position = new float[3];

        time[0] = EnviroSky.instance.GameTime.Hours;
        time[1] = EnviroSky.instance.GameTime.Hours;
        time[2] = EnviroSky.instance.GameTime.Hours;

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
