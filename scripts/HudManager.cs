using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    public Image currentEnergy;
    public Text time;

    private GameObject player;
    public Player playerInstance;

    public float health = 100f;
    private float maxHealth = 100f;
    public Image currentHealth;

    private int score;
    public Text scoreText;

    public Image currentArmor;
    public float armor = 0f;
    private float maxArmor = 100f;

    public float energy = 100f;
    private float maxEnergy = 100f;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_y;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject Inforamtion;

    [SerializeField] GameObject GameFinishMenu;
    [SerializeField] GameObject GameFinishInformation;
    string info;

    private string currentTime;
    private bool alreadySave = false;

    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = 1.5f;
        GameIsPaused = false;
        Time.timeScale = 1f;
        disableTorch();
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<Player_Movement>().isrun;
        input_x = player.GetComponent<Player_Movement>().x;
        input_y = player.GetComponent<Player_Movement>().y;
        health = player.GetComponent<HealthSystem>().playerHealth;
        armor = player.GetComponent<HealthSystem>().armorHealth;
        score = player.GetComponent<Player>().score;
        info = player.GetComponent<HealthSystem>().info;

        Text pesan = Inforamtion.GetComponent<Text>();
        pesan.text = info;

        showPauseMenu();
        updateHealth();
        updateArmor();
        EnergyDrain();
        UpdateEnergy();
        UpdateTime();
        UpdateScore();
        gameOver();
    }

    private void UpdateScore()
    {
        scoreText.text = "Your Score: " + score.ToString();
        if(score == 25)
        {
            gameFinish();
        }
    }

    private void disableTorch()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Torch");

        foreach (GameObject go in gameObjectArray)
        {
            go.transform.localPosition = new Vector3(0, 100, 0);
        }
    }

    public void gameFinish()
    {
        GameFinishMenu.SetActive(true);
        string finishInfo = "Score = " + score.ToString() + "\r\n" + "Time = " + currentTime.ToString();
        Text pesan = GameFinishInformation.GetComponent<Text>();
        pesan.text = finishInfo;
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (!alreadySave)
        {
            alreadySave = true;
            GameObject.Find("GameManager").GetComponent<DatabaseManagerScript>().saveScore(PlayerPrefs.GetString("playerName"), score.ToString(), currentTime.ToString());
        }
    }

    private void EnergyDrain()
    {
        if (kecepatan >= kecepatanLari)
        {
            energy -= 10 * Time.deltaTime;
        }
        else
        {
            energy += 15 * Time.deltaTime;
        }
        if (energy > 100)
        {
            energy = 100f;
        }
        if (energy < 0)
        {
            energy = 0;
        }
    }

    private void UpdateEnergy()
    {
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateTime()
    {
        int hours = EnviroSky.instance.GameTime.Hours;
        int minutes = EnviroSky.instance.GameTime.Minutes;
        string gameHours;
        string gameMinutes;

        if (hours >= 0 && hours < 10)
        {
            gameHours = "0" + hours.ToString();
        }
        else
        {
            gameHours = hours.ToString();
        }
        if (minutes >= 0 && minutes < 10)
        {
            gameMinutes = "0" + minutes.ToString();
        }
        else
        {
            gameMinutes = minutes.ToString();
        }

        currentTime = gameHours + " : " + gameMinutes;
        time.text = gameHours + " : " + gameMinutes;
    }

    private void showPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void updateHealth()
    {
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void updateArmor()
    {
        float ratio = armor / maxArmor;
        currentArmor.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(playerInstance);
        //DatabaseManagerScript
    }

    public void gameOver()
    {
        if (health < 1)
        {
            //player mati
            GameOverMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("South_Pacific_Town");
    }



}