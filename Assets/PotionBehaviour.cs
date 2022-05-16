using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehaviour : MonoBehaviour
{

    public GameObject nikLevel;
    public GameObject player;
    public GameObject potion;

    // Start is called before the first frame update
    void Start()
    {
        nikLevel.SetActive(false);
        potion.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            nikLevel.SetActive(true);
            potion.SetActive(false);
        }
    }
}
