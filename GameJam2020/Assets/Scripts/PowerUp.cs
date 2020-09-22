using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum TypeOfPowerUp
    {
        square, circle, triangle,
    }

    public TypeOfPowerUp powerUpType;
    public GameObject VirtualCam;
    private Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    public float shakeCameraIntensity = 4f;
    public float shakeCameraTime = 0.015f;

    private SpriteRenderer sr;


    // Start is called before the first frame update
    private void Awake()
    {
        c_VirtualCamera = VirtualCam.GetComponent<Cinemachine.CinemachineVirtualCamera>();
        sr = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShakeCamera(shakeCameraIntensity, shakeCameraTime, other.gameObject));
            AudioManager.instance.Play("Powerup");
        }
    }



    IEnumerator ShakeCamera(float intensity, float time, GameObject character)
    {
        Cinemachine.CinemachineBasicMultiChannelPerlin CMmultiChannel = c_VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        CMmultiChannel.m_AmplitudeGain = intensity;
        sr.enabled = false;
        if (character.name != "CircleCharacter" && powerUpType == TypeOfPowerUp.circle)
        {
            // Transformarse en circulo
            Transform parent = character.transform.parent;
            Transform newChar;
            if (parent.name == "RectangleScaler")
            {
                newChar = character.transform.parent.transform.parent.transform.GetChild(1);
            }
            else
            {
                newChar = character.transform.parent.transform.GetChild(1);

            }
            activateNewCharacter(newChar);
            changeCameraTarget(newChar);

            character.SetActive(false);

        }
        else if (character.name != "RectangleCharacter" && powerUpType == TypeOfPowerUp.square)
        {
            // Transformarse en cuadrado
            Transform newChar = character.transform.parent.transform.GetChild(0).GetChild(0);
            newChar.localScale = new Vector3(1, 1, 1);
            activateNewCharacter(newChar);
            changeCameraTarget(newChar);
            character.SetActive(false);

        }
        else if (character.name != "TriangleCharacter" && powerUpType == TypeOfPowerUp.triangle)
        {
            // Transformarse en triangulo
            Transform newChar = character.transform.parent.transform.GetChild(2);
            activateNewCharacter(newChar);
            changeCameraTarget(newChar);


            character.SetActive(false);
        }
        yield return new WaitForSeconds(time);
        CMmultiChannel.m_AmplitudeGain = 0f;
        Destroy(gameObject);


    }


    void changeCameraTarget(Transform newTarget)
    {
        c_VirtualCamera.m_Follow = newTarget;

    }

    void activateNewCharacter(Transform character)
    {
        character.transform.position = transform.position;
        character.gameObject.SetActive(true);
    }

}
