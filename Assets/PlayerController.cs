using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // add boolean
    public bool playerControlled;

    // track the position of the Ball object
    private GameObject ball;

    // array of all the Bots in the scene
    private GameObject[] bots;

    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // get the Ball object
        ball = GameObject.Find("Ball");

        // get all the Bots in the scene
        bots = GameObject.FindGameObjectsWithTag("Bot");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, ball.transform.position, Color.green);
        if (playerControlled) {
            // move robot based on WASD
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(x, 0.0f, z);
            transform.Translate(movement * Time.deltaTime * speed);

            // draw a debug line from self to ball
            
        } else {
            // find the closest GameObject ("Bot") to the ball
            // GameObject closest = null;
            // float closestDistance = 900.0f;
            // foreach (GameObject bot in bots) {
            //     float distance = Vector3.Distance(ball.transform.position, bot.transform.position);
            //     if (closest == null || distance < closestDistance) {
            //         closest = bot;
            //         closestDistance = distance;
            //     }
            // }

            // // if the closest is this object, move towards the ball
            // if (closest == gameObject) {
            //     Vector3 movement = ball.transform.position - transform.position;
            //     transform.Translate(movement * Time.deltaTime * speed);

            //     // draw a line from me to the ball
            //     Debug.DrawLine(transform.position, ball.transform.position, Color.red, 10.0f);
            // } else {
            //     Debug.DrawLine(transform.position, ball.transform.position, Color.red, 10.0f);
            // }
            

            // find direction of the ball
            Vector3 direction = ball.transform.position - transform.position;
            // move towards the ball
            transform.Translate(direction.normalized * Time.deltaTime * speed);
        }
    }
}
