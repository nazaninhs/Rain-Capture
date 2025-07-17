using System.Collections;
using UnityEngine;

public class FrogAnimationController : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void EatMosquito()
    {
        animator.SetBool("Eat", true);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        StartCoroutine(ResetEat());
    }

    IEnumerator ResetEat()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Eat", false);
    }
}
