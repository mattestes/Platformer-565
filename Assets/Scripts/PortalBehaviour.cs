using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public GameObject player;
    public int level;
    public LevelManager levelManager;
    public PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (dist < 1.5)
        {
            Debug.Log("Level complete");
            levelManager.CompleteLevel(level);
            pauseManager.Pause();
            Destroy(this.gameObject);
        }
    }

    // Not gonna use Colliders, just gonna use transform distance, I think
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Level 3 complete");
        }
    }
    */
}
