using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject ally { get; set; }
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject != ally)
        {
            Debug.Log("HIT OPPONENT!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("That's an ally!");
        }
    }
}
