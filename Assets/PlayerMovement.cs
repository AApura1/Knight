using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 movementInput;

    private Rigidbody2D rigidBody;

    private Animator anim;

    public int coincounter;

    public int health;

    public int Maxhealth = 100;

    public int trapDmg = 25;

    public int lavaDmg = 10;

    public int chest = 50;

    public Text CoinText;

    public Text HealthText;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = Maxhealth;
       
    }

    // Update is called once per frame
    private void Update()
    {


        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("speed", movementInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;

    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coincounter++;
            CoinText.text = "Coins: " + coincounter;
            Destroy(collision.gameObject);
        }


        if (collision.CompareTag("FireTRAP"))
        {
            health -= trapDmg;
            HealthText.text = "Health: " + health;
        }

        if (collision.CompareTag("Lava"))
        {
            health -= lavaDmg;
            HealthText.text = "Health: " + health;
        }


        if (collision.CompareTag("Chest"))
        {
            coincounter += chest;
            Destroy(collision.gameObject);
        }
    }
}



