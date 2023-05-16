/*
Keep track of points scored

Gilberto Echeverria
2023-04-19
*/


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

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
    HorizontalMovement motion;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        motion = GetComponent<HorizontalMovement>();
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
            // Disable the motion component to stop the player from moving
            motion.enabled = false;
            // Store the final score to be used in another scene
            PlayerPrefs.SetInt("TotalScore", points);
            throwBalls.Stop();
            scoreText.text += "\nYOU WON!";
            // Two ways to wait before changin the scene
            //Invoke("NextScene", 1);
            StartCoroutine(NextSceneInSeconds(2));
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene("Victory");
    }

    IEnumerator NextSceneInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Victory");
    }


}
