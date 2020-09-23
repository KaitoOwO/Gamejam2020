using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Canvas joystickCanvas;
    public Canvas EndCanvas;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        // sr = GetComponent<SpriteRenderer>();
    }

    public bool startedEndingScene = false;
    private bool buttonPressed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.CompareTag("Player"));
        if (other.CompareTag("Player"))
        {
            if (joystickCanvas.enabled != false && !startedEndingScene)
            {
                startedEndingScene = true;
                StartCoroutine(endkiss(other));
            }
        }
    }



    IEnumerator endkiss(Collider2D other)
    {
        other.gameObject.GetComponent<Animator>().SetTrigger("Kiss");
        gameObject.GetComponent<Animator>().SetTrigger("End");
        other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        joystickCanvas.enabled = false;
        AudioManager.instance.Play("Kiss");

        Debug.Log(other.gameObject.GetComponent<RectangleCharacterController>() != null);

        if (other.gameObject.GetComponent<RectangleCharacterController>() != null)
        {
            other.gameObject.GetComponent<RectangleCharacterController>().enabled = false;
            other.gameObject.GetComponent<RectanglePlayerMovement>().enabled = false;

        }
        else if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;


        }
        yield return new WaitForSeconds(1f);
        EndCanvas.gameObject.GetComponent<Animator>().SetTrigger("EndScene");
        yield return new WaitForSeconds(0.5f);
        EndCanvas.enabled = true;
    }

    public void returnToMainScene()
    {
        if (!buttonPressed)
        {
            buttonPressed = true;
            LevelManager.instance.loadLevelAsyncWithIndex(0);
        }

    }
}
