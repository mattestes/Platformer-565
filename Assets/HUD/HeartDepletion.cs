using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDepletion : MonoBehaviour
{
    bool heart1;
    bool heart2;


    void Start()
    {
        heart1 = true;
        heart2 = true;
        GameObject heart = GameObject.FindGameObjectWithTag("Heart1");
        Image image = heart.GetComponent<Image>();
        image.enabled = true;
        heart = GameObject.FindGameObjectWithTag("Heart2");
        image = heart.GetComponent<Image>();
        image.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (heart1)
            {
                GameObject heart = GameObject.FindGameObjectWithTag("Heart1");
                Image image = heart.GetComponent<Image>();
                image.enabled = false;
                heart1 = false;
            }
            else
            {
                GameObject heart = GameObject.FindGameObjectWithTag("Heart2");
                Image image = heart.GetComponent<Image>();
                image.enabled = false;
                heart2 = false;
            }
        }
    }

}
