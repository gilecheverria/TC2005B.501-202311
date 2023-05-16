/*
Display the points made in another scene, using PlayerPrefs to get them

Gilberto Echeverria
2023-05-16
*/

using UnityEngine;
using TMPro;

public class ShowPoints : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        int points = PlayerPrefs.GetInt("TotalScore", 0);
        text.text += "\nYou made " + points + " points!";
    }
}
