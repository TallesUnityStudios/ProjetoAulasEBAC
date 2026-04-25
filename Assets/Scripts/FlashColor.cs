using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    
    public List<SpriteRenderer> spriteRenderers; // List of SpriteRenderers to flash
    public Color color = Color.red; // Color to flash to
    public float flashDuration = .3f; // Duration of the flash in seconds

    private Tween _currentTween; // Reference to the current tween, if any

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>(); // Clear the list before adding new SpriteRenderers
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>()) // Get all SpriteRenderers in the children of this GameObject
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {

        if (_currentTween != null)
        {
            _currentTween.Kill(); // Stop the current tween if it's still running
            spriteRenderers.ForEach(i => i.color = Color.white); // Reset the color of all SpriteRenderers to white
        }

        foreach (var s in spriteRenderers) // Loop through each SpriteRenderer and apply the flash effect
        {
           _currentTween = s.DOColor(color, flashDuration).SetLoops(2, LoopType.Yoyo); // Flash to the specified color and back to the original color
        }
    }
}
