using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject infoPanel;

    public CanvasGroup infoPanelCanvasGroup;
    public float fadeSpeed = 0.5f;
    public Button infoExitButton;
    public Button StartGame;

    public Button goInfoPannel;
    public AudioSource menuMusic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Loading.LoadLevel("Level1", menuMusic);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void InfoEnable()
    {
        //fade in
        StartCoroutine(FadeIn());
        infoPanel.SetActive(true);
    }
    IEnumerator FadeIn()
    {
        float fadeGroup = 0f;
        infoPanelCanvasGroup.alpha = fadeGroup;
        goInfoPannel.gameObject.SetActive(false);
        StartGame.interactable = false;
        while (fadeGroup < 1)
        {
            fadeGroup += fadeSpeed * Time.deltaTime;
            fadeGroup = Mathf.Clamp01(fadeGroup);
            infoPanelCanvasGroup.alpha = fadeGroup;
            yield return new WaitForEndOfFrame();
        }
        infoExitButton.enabled = true;
    }
    public void InfoDisable()
    {
        //fade out
        StartCoroutine(FadeOut());
        
    }
    IEnumerator FadeOut()
    {
        float fadeGroup = 1f;
        while (fadeGroup > 0)
        {
            fadeGroup -= fadeSpeed * Time.deltaTime;
            fadeGroup = Mathf.Clamp01(fadeGroup);
            infoPanelCanvasGroup.alpha = fadeGroup;
            yield return new WaitForEndOfFrame();
        }
        infoPanel.SetActive(false);
        infoExitButton.enabled = false;
        goInfoPannel.gameObject.SetActive(true);
        StartGame.interactable = true;
    }
}
