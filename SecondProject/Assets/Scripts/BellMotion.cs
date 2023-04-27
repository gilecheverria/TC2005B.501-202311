/*
Simulate the ringing of a bell when the player scores
Uses a simple animation using Linear Interpolation (Lerp) over the angle
of the rotation
Generates a sound
The method StartRing can be called from other scripts to initiate the action

Gilberto Echeverria
2023-04-26
*/

using UnityEngine;

public class BellMotion : MonoBehaviour
{
    // Limits of the motion range
    [SerializeField] float angleLimit;
    [SerializeField] float speed;
    [SerializeField] float ringDuration;
    // Variable to control how the bell slowly stops moving
    [SerializeField] float motionDecay;
    
    // Reference to the component to play the sound
    AudioSource audioSource;
    // Rotation angle for the GameObject
    float angle;
    // Direction of the rotation, left (-1) or right (1)
    int direction = 1;
    // Variable to control the Lerp interpolation.
    // Should have a value between 0 and 1, corresponding to the
    // initial an final values respectively
    float t;
    bool isRinging = false;
    // Variable to keep track of how long the bell has been animating
    float timeElapsed;
    // Varible to reduce the rotation of the bell over time
    float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRinging) {
            Ring();
            timeElapsed += Time.deltaTime;
            // Reduce the motion of the bell over time
            multiplier -= motionDecay * Time.deltaTime;
            // Check when the animation should stop
            if(timeElapsed > ringDuration) {
                isRinging = false;
            }
        }

        // Test code to check the whole effect of the bell
        if(Input.GetKeyDown(KeyCode.R)) {
            StartRing();
        }
    }

    // Initialize variables when the bell starts ringing
    // This method can be called from other classes
    public void StartRing()
    {
        t = 0.5f;
        timeElapsed = 0;
        isRinging = true;
        multiplier = 1;
        audioSource.Play();
    }

    // Perform the animation of the bell
    void Ring()
    {
        // Compute the new rotation angle, betwen the two limits
        angle = Mathf.Lerp(-angleLimit, angleLimit, t) * multiplier;
        // Apply the rotation to the gameObject
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Update the value that controls the animation
        t += direction * speed * Time.deltaTime;

        // Change the direction of the animation when reaching the endpoints
        if(t > 1 || t < 0) {
            direction *= -1;
        }
    }
}