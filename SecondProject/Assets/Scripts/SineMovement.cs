/*
Move in a regular pattern, using Sine function

Gilberto Echeverria
2023-04-26
*/

using UnityEngine;

public class SineMovement : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    float angle;
    Vector3 origin;

    void Start()
    {
        // Register the original position of the object
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Compute a new position, using the sine
        transform.position = origin + direction * Mathf.Sin(angle) * amplitude; 
        // Update the value of the angle for the sine,
        // adjusting it for varible Frame Rates,
        // adjusting it for varible Frame Rates
        angle += speed * Time.deltaTime;
    }
}