using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    public KeyCode keyToTrigger = KeyCode.A; // The key to press to trigger the animation
    public KeyCode KeyToExit = KeyCode.S; // The key to press to exit the animation
    public string triggerToPlay = "attack"; // The name of the trigger parameter in the Animator

    private void OnValidate()
    {
        // Ensure that the Animator component is assigned
        if (animator == null) animator = GetComponent<Animator>(); // Try to get the Animator component from the same GameObject if not assigned
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToTrigger)) // Check if the 'S' key is pressed
        {
            animator.SetBool(triggerToPlay, true); // Set the trigger to play the animation
        }
        else if (Input.GetKeyUp(KeyToExit)) // Check if the 'S' key is released
        {
            animator.SetBool(triggerToPlay, false); // Reset the trigger to stop the animation
        }
    }
}
