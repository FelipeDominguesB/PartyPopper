using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{

    double currentScore = 0.0;

    public Text scoreText;
    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getCurrentHealth() == 0)
        {

        }

    }


    public void IncreaseScore(int score)
    {
        currentScore += score;
        scoreText.text = $"Score: {currentScore}";
    }
}
