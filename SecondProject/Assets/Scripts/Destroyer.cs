/*
Eliminate prefabs that touch this object

Gilberto Echeverria
2023-04-18
*/

using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
