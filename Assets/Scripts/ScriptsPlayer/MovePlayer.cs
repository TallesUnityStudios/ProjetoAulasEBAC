using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //This script is responsible for moving the player left and right.
    public Rigidbody2D MyRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float MoveSpeed;

    //This script is responsible for jumping the player.
    public float JumpForce = 3;

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    //This method handles the movement of the player left and right.
    //Este método lida com o movimento do jogador para a esquerda e para a direita.
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Move the player to the left
            //MyRigidbody.MovePosition(MyRigidbody.position - Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(-MoveSpeed, MyRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Move the player to the right
            //MyRigidbody.MovePosition(MyRigidbody.position + Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(MoveSpeed, MyRigidbody.velocity.y);
        }

        //Apply friction to slow down the player when they are not pressing any movement keys
        //Aplicar atrito para desacelerar o jogador quando ele não estiver pressionando nenhuma tecla de movimento
        if (MyRigidbody.velocity.x > 0)
        {
            MyRigidbody.velocity += friction;
        }
        else if (MyRigidbody.velocity.x < 0)
        {
            MyRigidbody.velocity -= friction;
        }
    }

    //This method handles the jumping of the player.
    //Este método lida com o salto do jogador.
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyRigidbody.velocity = Vector2.up * JumpForce;
        }
    }
}
