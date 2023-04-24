/*
Keep track of points scored

Gilberto Echeverria
2023-04-19
*/

using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] ParticleSystem particles;

    int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        points += 1;
        scoreText.text = "Score: " + points;
        particles.Emit(15);
    }
}