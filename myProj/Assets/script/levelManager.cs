using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public int gemsCollected;
    public float waitToRespawn;
    public static levelManager instance;
    public GameObject Panel;
    public string levelToLoad;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Time.timeScale = 0f;
        SoundManagerScript.instance.PlaySound(12);
    }

    // Update is called once per frame
    void Update()
    {
        UIController.instance.HealthDisplay();
    }
    public void respawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }


    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        CameraController.instance.StopFollow = true;
        UIController.instance.levelEndtext.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelToLoad);


      

    }
    private IEnumerator RespawnCo()
    {
        PlayerhealthController.instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitToRespawn - (1 / UIController.instance.FadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds(waitToRespawn - (1 / UIController.instance.FadeSpeed));
        UIController.instance.FadeFromBlack();
        PlayerhealthController.instance.gameObject.SetActive(true);
        PlayerScript.instance.transform.position = CPController.instance.spawnpoint;
        PlayerhealthController.instance.currentHealth = PlayerhealthController.instance.maxHealth;
        UIController.instance.HealthDisplay();
    }


}
