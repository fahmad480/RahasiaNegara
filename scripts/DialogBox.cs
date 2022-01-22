using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public Transform box;
    public CanvasGroup background;
    // Start is called before the first frame update
    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(0.8f, 0.5f).setIgnoreTimeScale(true);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setIgnoreTimeScale(true).setEaseOutExpo().delay = 0.1f;
    }

    // Update is called once per frame
    public void CloseDialog()
    {
        background.LeanAlpha(0, 0.5f).setIgnoreTimeScale(true);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete).setIgnoreTimeScale(true);
    }
    void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
