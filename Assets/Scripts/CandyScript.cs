using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Increment score, destroy the candy
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Boundary")
        {
            //Decrement lives, destroy the candy
            GameManager.instance.DecrementLives();
            Destroy(gameObject);
        }
    }

}
