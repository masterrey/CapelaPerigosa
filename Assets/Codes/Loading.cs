using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public static string levelToLoad;  
    AsyncOperation async;

    public bool isLoading = false;

    public static AudioSource audioRemanecente;
    // Start is called before the first frame update
    void Start()
    {
        if (audioRemanecente != null)
        {
            VolumeFadeout();
        }
        else
        {
            async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelToLoad);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Load the level
    /// </summary>
    /// <param name="level"></param>
    public static void LoadLevel(string level)
    {
        levelToLoad = level;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }

    public static void LoadLevel(string level,AudioSource audioReminicent)
    {
        levelToLoad = level;
        if(audioReminicent != null)
        {
            audioRemanecente = audioReminicent;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
        
    }

    void VolumeFadeout()
    {
        StartCoroutine(VolumeFadeOut());
    }
    
    IEnumerator VolumeFadeOut()
    {
        float startVolume = audioRemanecente.volume;
        while (audioRemanecente != null && audioRemanecente.volume > 0)
        {
            audioRemanecente.volume -= startVolume * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if(audioRemanecente != null)
        {
            audioRemanecente.Stop();
            audioRemanecente.volume = startVolume;
            Destroy(audioRemanecente.gameObject);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
        
    }
}
