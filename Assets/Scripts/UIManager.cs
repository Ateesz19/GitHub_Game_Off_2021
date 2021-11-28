using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject playerBody;
    private int score;

    private Enemy enemyS;
    private PlayerMove pM;
    private Bullet bulletS;

    private void Awake()
    {
        enemyS = GetComponent<Enemy>();
        pM = GetComponent<PlayerMove>();
        bulletS = GetComponent<Bullet>();
    }

    private void Start()
    {
        score = 0;
    }

    public void Update()
    {
        AddScore(1);
    }

    public void AddScore(int scoreToPlayer)
    {
        if (playerBody.activeInHierarchy)
        {
            score += scoreToPlayer;
            scoreText.text = "Score: " + score;
        }
    }
}
