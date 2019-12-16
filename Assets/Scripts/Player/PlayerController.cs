using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Joystick joy;
    [SerializeField] SpriteRenderer weapon;

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
        if(Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            dir += Vector2.left;
        }
        if(Input.GetKey(KeyCode.W))
        {
            dir += Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        rb.velocity = dir.normalized * speed * Time.deltaTime;
        if ((dir.x > 0 && weapon.flipX) || (dir.x < 0 && !weapon.flipX))
            weapon.flipX ^= true;
        anim.SetFloat("velocityX",dir.x);
        anim.SetFloat("velocity", dir.magnitude);
    }


}
