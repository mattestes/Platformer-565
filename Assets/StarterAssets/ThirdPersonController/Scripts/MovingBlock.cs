using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private float start;
    private float end;
    public float distance;
    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.z;
        end = transform.position.z + distance;

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speedMultiplier, distance) + start);
    }

}
