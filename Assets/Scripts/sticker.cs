using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sticker : MonoBehaviour
{
    public bool IsFinished;

    [SerializeField] private Color Active;
    [SerializeField] private Color Inactive;

    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if (IsFinished)
        {
            image.color = Active;
        }
        else
        {
            image.color = Inactive;
        }


    }
}
