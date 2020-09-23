using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpad : MonoBehaviour
{

    public float jumpForce = 1000f;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && other.gameObject.name == "CircleCharacter")
        {
            other.attachedRigidbody.velocity = new Vector2(0, 0);
            other.attachedRigidbody.AddForce(transform.up * jumpForce);
            AudioManager.instance.Play("Jump");
        }
    }


}
