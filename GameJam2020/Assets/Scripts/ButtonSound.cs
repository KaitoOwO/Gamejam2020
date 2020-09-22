using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSound : MonoBehaviour
{
    public AudioSource fuente;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        fuente.clip = clip;
    }

    public void Reproducir()
    {
        fuente.Play();
    }
}
