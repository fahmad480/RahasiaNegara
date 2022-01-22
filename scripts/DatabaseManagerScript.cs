using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;

public class DatabaseManagerScript : MonoBehaviour
{
    SqliteConnection con;
    public string conn = string.Empty;

    public GameObject TBodyPrefab;
    public GameObject ScoreBoardTBody;

    // Start is called before the first frame update
    void Start()
    {
        InitDB();
    }  

    void InitDB()
    {
        try
        {
            conn = "URI=file:" + Directory.GetCurrentDirectory() + @"\DB.db";
            con = new SqliteConnection(conn);
            Debug.Log("Connected To Database");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Not Connected To Database");
        }
    }

    public void saveGameToDB()
    {

    }

    public void showScoreBoard()
    {
        try
        {
            con.Open();

            SqliteCommand com = con.CreateCommand();
            string query = "SELECT * FROM score ORDER BY score";
            com.CommandText = query;
            SqliteDataReader reader = com.ExecuteReader();

            foreach (Transform child in ScoreBoardTBody.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            int i = 1;
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int score = reader.GetInt32(2);
                string time = reader.GetString(3);
                //Debug.Log("ID: " + id + "\r\nName: " + name + "\r\nScore: " + score + "\r\nTime: " + time);
                GameObject go = Instantiate(TBodyPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                go.transform.parent = ScoreBoardTBody.transform;
                go.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = name;
                go.transform.GetChild(2).GetComponent<Text>().text = score.ToString();
                go.transform.GetChild(3).GetComponent<Text>().text = time;
                i++;
            }

            con.Close();
        }
        catch (System.Exception ex)
        {
            Debug.Log("error showScoreBoard");
            Debug.LogError(ex);
        }
    }

    public void saveScore(string _name, string _score, string _time)
    {
        try
        {
            con.Open();

            SqliteCommand com = con.CreateCommand();
            string query = "INSERT INTO score(name, score, time) VALUES ('" + _name + "', '" + _score + "', '" + _time + "')";

            com.CommandText = query;
            if (com.ExecuteNonQuery() > 0)
                Debug.Log("success saveScore");

            con.Close();
        }
        catch (System.Exception ex)
        {
            Debug.Log("error saveScore");
            Debug.LogError(ex);
        }
    }
}
