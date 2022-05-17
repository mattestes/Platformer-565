using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinning : MonoBehaviour
{
    public float degree;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, degree * Time.deltaTime, 0);
    }
}
