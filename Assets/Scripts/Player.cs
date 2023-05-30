using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private GameObject prefabFireball;

    private GameObject otherPlayer;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject player in players)
        {
            if(player != gameObject)
            {
                otherPlayer = player;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
        Attacks();
    }

    private void HorizontalMovement()
    {
        Vector2 currentVelocity = rb.velocity;
        
        if(Input.GetKey("d"))
        {
            currentVelocity[0] = moveSpeed;
            rb.velocity = currentVelocity;
        }
        else if(Input.GetKey("a"))
        {
            currentVelocity[0] = -moveSpeed;
            rb.velocity = currentVelocity;
        }
        else
        {
            currentVelocity[0] = 0;
        }
        rb.velocity = currentVelocity;
    }

    private void VerticalMovement()
    {
        Vector2 currentVelocity = rb.velocity;
        Vector3 currentScale = transform.localScale;

        if (Input.GetKeyDown("w"))
        {
            currentVelocity[1] = jumpSpeed;
            rb.velocity = currentVelocity;
        }
        else if (Input.GetKey("s"))
        {
            
            currentScale[1] = .5f;
            transform.localScale = currentScale;
        }
        else if (Input.GetKeyUp("s"))
        {
            currentScale[1] = 1;
            transform.localScale = currentScale;
        }
    }
    
    private void Attacks()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject fireball = Instantiate(prefabFireball);
            fireball.GetComponent<Fireball>().opponent = otherPlayer;
            fireball.transform.position = transform.position;
        }
    }
}
