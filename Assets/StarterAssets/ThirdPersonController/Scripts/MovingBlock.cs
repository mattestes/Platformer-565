using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float maxX;
    public float maxY;
    public float maxZ;
    private float xCount;
    private float yCount;
    private float zCount;
    // Start is called before the first frame update
    void Start()
    {
        xCount = 0;
        yCount = 0;
        zCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(xCount > maxX || xCount < maxX * -1)
        {
            x = x * -1;
        }
        if (yCount > maxY || yCount < maxY * -1)
        {
            y = y * -1;
        }
        if (zCount > maxZ || zCount < maxZ * -1)
        {
            z = z * -1;
        }
        transform.position = new Vector3(x, y, z) * Time.deltaTime;
        xCount += x;
        yCount += y;
        zCount += z;

    }
}
