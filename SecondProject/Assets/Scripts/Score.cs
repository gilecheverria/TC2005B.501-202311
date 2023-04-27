/*
Keep track of points scored

Gilberto Echeverria
2023-04-19
*/

using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // References to other components
    // These are filled from within Unity, by dragging the component or object
    // into the corresponding field
    [SerializeField] TMP_Text scoreText;
    [SerializeField] ParticleSystem particles;
    [SerializeField] BellMotion bell;
    [SerializeField] ThrowBalls throwBalls;
    [SerializeField] int pointLimit;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        points += 5;
        scoreText.text = "Score: " + points;
        // Generate a few particles from the game object that is a child of
        // the one with this script
        particles.Emit(20);
        // Call the method on another script to make the bell ring
        bell.StartRing();

        // Finish the game when reaching a certain number of points
        if(points == pointLimit) {
            throwBalls.Stop();
            scoreText.text += "\nYOU WON!";
        }
    }
}
