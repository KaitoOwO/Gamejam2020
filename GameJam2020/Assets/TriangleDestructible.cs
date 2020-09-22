using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDestructible : MonoBehaviour
{
    public GameObject VirtualCam;
    private Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    public float shakeCameraIntensity = 10f;
    public float shakeCameraTime = 0.015f;

    private void Awake()
    {
        c_VirtualCamera = VirtualCam.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        // sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log(other.collider.CompareTag("Player"));
        if (other.collider.CompareTag("Player") && other.collider.gameObject.name == "TriangleCharacter")
        {
            GetComponent<BoxCollider2D>().enabled = false;

            Animator characterAnimator = other.gameObject.GetComponent<Animator>();
            characterAnimator.SetBool("Dizzy", true);
            StartCoroutine(ShakeCamera(shakeCameraIntensity, shakeCameraTime, characterAnimator));
        }
    }

    IEnumerator ShakeCamera(float intensity, float time, Animator characterAnimator)
    {
        Cinemachine.CinemachineBasicMultiChannelPerlin CMmultiChannel = c_VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        CMmultiChannel.m_AmplitudeGain = intensity;
        // sr.enabled = false;
        yield return new WaitForSeconds(time);
        characterAnimator.SetBool("Dizzy", false);
        CMmultiChannel.m_AmplitudeGain = 0;
        Destroy(gameObject);


    }
}
