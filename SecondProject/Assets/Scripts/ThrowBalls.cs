/*
Create copies of a ball object to fall on the game scene
The balls fall at regular intervals from random positions above the screen

Gilberto Echeverria
2023-04-18
*/

using UnityEngine;

public class ThrowBalls : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float delay;
    [SerializeField] float limit;

    // Start is called before the first frame update
    void Start()
    {
        // Call the specified function at regular intervals
        InvokeRepeating("CreateBall", delay, delay);
    }

    public void Stop()
    {
        // Cancell the repeated call of the function, so the balls stop falling
        CancelInvoke("CreateBall");
    }

    void CreateBall()
    {
        // Generate a random position in X and over the view of the camera
        Vector3 newPos = new Vector3(Random.Range(-limit, limit),
                                     6.5f, 0);
        // Create a copy of the ball prefab
        Instantiate(ball, newPos, Quaternion.identity);
    }
}
