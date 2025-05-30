using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
   // private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (playerControllerScript.gameOver == false)
        {
            if (playerControllerScript.isDashing == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime * playerControllerScript.dash);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            //if( transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            // {
            //  Destroy(gameObject);
            //  }
        }   }   
}
