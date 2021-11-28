using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rBody;
    private BoxCollider2D boxCol;
    private UIManager uiM;
    private Enemy enemyS;
    private SpriteRenderer spriteX;
    private AudioSource audioS;

    private Transform rot;
    public float fixRot = 0.0f;

    float speed = 3f;
    float zerospeed = 0f;
    float playerRange = 8f;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        uiM = GetComponent<UIManager>();
        enemyS = GetComponent<Enemy>();
        rot = transform;
        audioS = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        spriteX = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMovement();
        StayInArea();
        ExitGameToMenu();
        rot.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void PlayerMovement()
    {        
        if (Input.GetKey(KeyCode.A))
        {
            rBody.velocity = new Vector2(-speed, rBody.velocity.y);
            spriteX.flipX = true;
        }else if(Input.GetKey(KeyCode.D))
        {
            rBody.velocity = new Vector2(+speed, rBody.velocity.y);
            spriteX.flipX = false;
        }else
        {
            rBody.velocity = new Vector2(zerospeed, rBody.velocity.y);
        }
    }

    void StayInArea()
    {
        if (rBody.position.x < -playerRange)
        {
            rBody.position = new Vector2(-playerRange, rBody.position.y);
        }else if(rBody.position.x > playerRange)
        {
            rBody.position = new Vector2(playerRange, rBody.position.y);
        }
    }

    public void ExitGameToMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
