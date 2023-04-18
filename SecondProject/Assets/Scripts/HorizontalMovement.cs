/*
Move the player object horizontally using the keyboard

Gilberto Echeverria
2023-04-18
*/

using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float limit;

    Vector3 move;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");

        if (transform.position.x < -limit && move.x < 0) {
            move.x = 0;
        } else if (transform.position.x > limit && move.x > 0) {
            move.x = 0;
        }

        transform.Translate(move * speed * Time.deltaTime);
    }
}
