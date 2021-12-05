using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class pickup : MonoBehaviour
{
    public bool isGem;
    private bool isCollected;
    public bool isHealthPack;
    public bool isBigHealthPack;
    public GameObject pickupEffect;
    public int coin;
    public GameObject cointext;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        cointext.GetComponent<Text>().text = "my coinT" + coin; 
    }

    // Update is called once per frame
    void Update()
    {
        cointext.GetComponent<Text>().text = "my coinT" + coin;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (isGem)
            {
                Debug.Log("working");
                //levelManager.instance.gemsCollected++;

                coin +=5;
                
                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                SoundManagerScript.instance.PlaySound(6);
                //UIController.instance.gemUpdateCount();
            }

            if (isHealthPack)
            {
                if (PlayerhealthController.instance.currentHealth != PlayerhealthController.instance.maxHealth)
                {
                    PlayerhealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    SoundManagerScript.instance.PlaySound(7);
                }
            }

            if (isBigHealthPack)
            {
                if (PlayerhealthController.instance.currentHealth != PlayerhealthController.instance.maxHealth)
                {
                    PlayerhealthController.instance.BigHealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    SoundManagerScript.instance.PlaySound(7);
                }
            }
        }
    }
}

