using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //GameObject score = GameObject.FindGameObjectWithTag("Score");
            //score.GetComponent<Score>().addScore(10);
            addScore(10);
        }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
