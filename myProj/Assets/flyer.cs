using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyer: MonoBehaviour
{
   
    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerScript.instance.rb.velocity = new Vector2(PlayerScript.instance.rb.velocity.x, bounceForce);
            
        }
    }
}