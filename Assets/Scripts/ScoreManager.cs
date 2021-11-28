using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public GameObject playerBody;

    private Bullet bulletS;

    public int score;
    public int scoremulti = 1;

    private void Start()
    {
        bulletS = GetComponent<Bullet>();
        score = 0;
    }

    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        AddScore(scoremulti);
    }

    public void AddScore(int scoreToPlayer)
    {
        scoreText.text = "Score: " + score;
    }
}
