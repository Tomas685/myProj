using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect;
    public string mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;
    public ParticleSystem fireCamp;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            PauseUnpause();
            SoundManagerScript.instance.PlaySound(4);
        }


    }

    public void Levelselect()
    {
        
        SceneManager.LoadScene(levelSelect);
        SoundManagerScript.instance.PlaySound(4);
    }

    public void MainMenu()
    {
        
        SceneManager.LoadScene(mainMenu);
        SoundManagerScript.instance.PlaySound(4);
    }
    public void PauseUnpause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}