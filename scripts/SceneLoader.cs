using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    public Text loadingText;
    public static bool loadStatus;

    // Start is called before the first frame update
    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = false;
    }

    public void LoadSaveGame(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = true;
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            int progress = (int)Mathf.Clamp01(operation.progress / .9f);

            loadingBar.value = progress;
            loadingText.text = progress * 100 + "%";

            yield return null;
        }
    }

    public void saveNickname()
    {
        PlayerPrefs.SetString("playerName", GameObject.Find("InputNickName").GetComponent<InputField>().text);
        Debug.Log("playerName saved " + GameObject.Find("InputNickName").GetComponent<InputField>().text);
    }
}
