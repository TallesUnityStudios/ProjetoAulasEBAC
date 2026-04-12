using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody2D MyRigidbody;
    public Vector2 Velocity;
    public float MoveSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //MyRigidbody.MovePosition(MyRigidbody.position - Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(-MoveSpeed, MyRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //MyRigidbody.MovePosition(MyRigidbody.position + Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(MoveSpeed, MyRigidbody.velocity.y);
        }
    }
}
