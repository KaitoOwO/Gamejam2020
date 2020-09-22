using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Canvas joystickCanvas;
    public Canvas EndCanvas;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.CompareTag("Player"));
        if (other.CompareTag("Player"))
        {
            if (joystickCanvas.enabled != false)
            {
                StartCoroutine(endkiss(other));

            }
        }
    }

    IEnumerator endkiss(Collider2D other)
    {
        other.gameObject.GetComponent<Animator>().SetTrigger("Kiss");
        gameObject.GetComponent<Animator>().SetTrigger("End");
        joystickCanvas.enabled = false;
        AudioManager.instance.Play("Kiss");
        yield return new WaitForSeconds(0.5f);
        EndCanvas.enabled = true;
        EndCanvas.gameObject.GetComponent<Animator>().SetTrigger("EndScene");
        yield return new WaitForSeconds(3f);
        LevelManager.instance.loadLevelAsyncWithIndex(0);

    }
}
