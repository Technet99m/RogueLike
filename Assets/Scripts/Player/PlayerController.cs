using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Joystick joy;

    public static Transform player;
    private void Awake()
    {
        player = transform;
    }
    void Start()
    {
        joy.DeadZone = 0.1f;
    }
    void Update()
    {
        Vector2 dir = new Vector2();
        dir = new Vector2(joy.Horizontal, joy.Vertical);
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector2.right;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector2.left;
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector2.down;
        }
        rb.velocity = dir.normalized * speed * Time.deltaTime; 
        anim.SetFloat("velocityX",dir.x);
        anim.SetFloat("velocity", dir.magnitude);
    }


}
