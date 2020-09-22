using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollableImage : MonoBehaviour
{
    [SerializeField]
    RawImage scrollableImage;
    [SerializeField]
    float scrollSpeed;
    Rect rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = scrollableImage.uvRect;
    }

    // Update is called once per frame
    void Update()
    {
        rect.x += scrollSpeed * Time.deltaTime;
        scrollableImage.uvRect = rect;
    }
}
