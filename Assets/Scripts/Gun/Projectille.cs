using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour
{
    public Vector3 direction; // Direction in which the projectille will move
    public float timeToDestroy = 2f; // Time in seconds before the projectille is destroyed
    public float side = 1;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy); // Schedule the destruction of the projectille after the specified time
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side); // Move the projectille in the specified direction every frame
    }
}
