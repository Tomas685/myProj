using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup1 : MonoBehaviour
{
    public GameObject text;
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        text.GetComponent<Text>().text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = coin.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coin++;
        }
    }
}
