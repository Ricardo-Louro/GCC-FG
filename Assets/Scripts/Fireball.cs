using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject opponent { get; set; }
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if(transform.position.x < opponent.transform.position.x)
        {
            rb.velocity = new Vector2(5, 0);
        }
        else
        {
            rb.velocity = new Vector2(-5, 0);
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale[0] = -1;
            gameObject.transform.localScale = currentScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == opponent)
        {
            Debug.Log("HIT OPPONENT!");
            Destroy(gameObject);
        }
        else if(other.GetComponent<Fireball>() is not null)
        {
            Debug.Log("FIREBALLS COLLIDED!");
            Destroy(gameObject);
        }
    }
}
