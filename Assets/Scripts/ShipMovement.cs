using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public LogicManager logic;
    public AudioPlayerScript audioPlayer;
    public HealthManager health;

    [Header("Ship Properties")]
    public float movSpeed = 6f;
    public float focusSpeed = 2f;
    public int shipHealth = 3;
    public KeyCode focusKey = KeyCode.LeftShift;
    public KeyCode fireKey = KeyCode.Space;
    public GameObject hitboxSprite;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isFocusing => Input.GetKey(focusKey);

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthManager>();
        audioPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioPlayerScript>();

        rb = GetComponent<Rigidbody2D>();
        hitboxSprite.SetActive(false);

        LoadMove();
        LoadFocus();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        hitboxSprite.SetActive(isFocusing ? true : false);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection.normalized * (isFocusing ? focusSpeed : movSpeed) * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        shipHealth -= damage;

        if (shipHealth == 2) {
            health.damaged1();
            audioPlayer.sfxPlayerDamaged();
        } else if (shipHealth == 1) {
            health.damaged2();
            audioPlayer.sfxPlayerDamaged();
        } else if (shipHealth <= 0) {
            health.damaged3();
            audioPlayer.sfxPlayerDie();
            GameOver();
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
        logic.gameOver();
    }

    void LoadMove()
    {
        movSpeed = PlayerPrefs.GetInt("moveSpeed");
    }

    void LoadFocus()
    {
        focusSpeed = PlayerPrefs.GetInt("focusSpeed");
    }
}
