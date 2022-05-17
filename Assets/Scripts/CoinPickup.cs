using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    CoinConstants coinConstants;
    GameObject target;
    GameObject scorePanel;

    // Start is called before the first frame update
    void Start()
    {
        coinConstants = this.gameObject.transform.parent.gameObject.GetComponent<CoinConstants>();
        target = coinConstants.player;
        scorePanel = coinConstants.scorePanel;
    }

    // Update is called once per frame
    void Update()
    {
        
        // this.gameObject.transform
        float dist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
        if(dist < 1.5)
        {
            Debug.Log("Coin picked up");
            scorePanel.GetComponent<Score>().addScore(10);
            Destroy(this.gameObject);
        }
    }
}
