using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestscript : MonoBehaviour
{
    public Animator anim;
    public int chest = 50;
    public bool playerOnTop;
    public PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        playerOnTop = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = true;
            anim.SetBool("Open", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = false;
            anim.SetBool("Close", false);
        }
    }

    public void Tresure()
    {
        if (playerOnTop)
        {
            player.coincounter += chest;
        }
    }

}
