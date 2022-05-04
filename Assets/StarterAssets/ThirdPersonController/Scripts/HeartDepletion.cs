using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDepletion : MonoBehaviour
{

    public GameObject heartSprite;
    public int heartCount = 3;
    List<GameObject> hearts = new List<GameObject>();

    void Start()
    {

        for (int i = 0; i < heartCount; i++)
        {
            GameObject newHeart = Instantiate(heartSprite, new Vector3(75 + 125 * i, transform.position.y, 0), Quaternion.identity);
            newHeart.transform.parent = this.transform;
            hearts.Add(newHeart);
        }

    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0))
        {
            removeHeart();
        }
        
        
        if (Input.GetMouseButtonUp(1))
        {
            addHeart();
        }
        */

    }

    public void removeHeart()
    {
        if(heartCount > 0)
        {
            heartCount--;
            Destroy(hearts[heartCount]);
            hearts.RemoveAt(heartCount);
        }
        if (heartCount == 0)
        {
            PauseManager pauseManager = this.gameObject.transform.parent.gameObject.GetComponent<PauseManager>();
            pauseManager.GameOver();
        }
    }

    public void addHeart()
    {
        GameObject newHeart = Instantiate(heartSprite, new Vector3(75 + 125 * heartCount, transform.position.y, 0), Quaternion.identity);
        newHeart.transform.parent = this.transform;
        hearts.Add(newHeart);
        heartCount++;
    }

}
