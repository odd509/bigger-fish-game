using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject joystick;
    
    public float speed = 10f;

    private Rigidbody2D rb;
    private Vector2 move;
    private MobileInputController joystickInput;

    private void Start()
    {
        joystickInput = joystick.GetComponent<MobileInputController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 coords = joystickInput.Coordinate();
        rb.velocity = coords * speed;
        Flip(coords.x);
    }
    void Flip(float x)
    {
        Transform ts = transform;
        if ((x > 0 && ts.localScale.x > 0) || x < 0 && ts.localScale.x < 0) ts.localScale = new Vector3(-ts.localScale.x, ts.localScale.y, ts.localScale.z);
    }
}
