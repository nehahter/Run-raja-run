using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the character!");
        }
    }

    public void PlayRunAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isRunning", true);
        }
    }

    public void StopRunAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void PlayJumpAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("jump");
        }
    }

    // Add other animation-related methods as needed
}
