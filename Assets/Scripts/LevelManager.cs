using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CharacterController charController;
    int currentLevel;
    public GameObject[] levels;

    bool[] levelComplete;
    

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        levelComplete = new bool[levels.Length];
        for(int i = 0; i < levelComplete.Length; i++)
        {
            levelComplete[i] = false;
        }
    }

    public void CompleteLevel(int level)
    {
        levelComplete[level - 1] = true;
    }

    public void StartLevel()
    {
        Debug.Log("Starting level");
        charController.enabled = false;
        charController.transform.position = levels[currentLevel - 1].transform.position;
        charController.transform.rotation = levels[currentLevel - 1].transform.rotation;
        charController.enabled = true;
        
    }

    public void NextLevel()
    {
        if(currentLevel < levels.Length)
        {
            currentLevel++;
        }
        StartLevel();
    }

    public bool currentComplete()
    {
        return levelComplete[currentLevel - 1] && currentLevel < levels.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
