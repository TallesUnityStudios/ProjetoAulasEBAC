using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlayer : MonoBehaviour
{
    //This script is responsible for moving the player left and right.
    public Rigidbody2D MyRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float MoveSpeed;
    public float SpeedRun; //This script is responsible for making the player run
    public float JumpForce = 3; //This script is responsible for jumping the player.

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f; //This script is responsible for scaling the player when they jump
    public float jumpScaleX = 0.8f; //This script is responsible for scaling the player when they jump
    public float animationDuration = 0.3f; //This script is responsible for the duration of the jump animation
    public Ease ease = Ease.OutBack; //This script is responsible for the easing of the jump animation

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMoviment(); 
    }

    //This method handles the movement of the player left and right.
    //Este método lida com o movimento do jogador para a esquerda e para a direita.
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = SpeedRun;
        else
            _currentSpeed = MoveSpeed;
            
        if (Input.GetKey(KeyCode.A))
        {
            //Move the player to the left
            //MyRigidbody.MovePosition(MyRigidbody.position - Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(-_currentSpeed, MyRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Move the player to the right
            //MyRigidbody.MovePosition(MyRigidbody.position + Velocity * Time.deltaTime);
            MyRigidbody.velocity = new Vector2(_currentSpeed, MyRigidbody.velocity.y);
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
            MyRigidbody.transform.localScale = Vector3.one; //Reset the scale to normal before applying the jump animation

            DOTween.Kill(MyRigidbody.transform); //Kill any existing tweens on the player's transform to prevent conflicts

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        MyRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        MyRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
