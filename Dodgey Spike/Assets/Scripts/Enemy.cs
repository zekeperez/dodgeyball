using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 5; //amount of bounces left

    ColorPallette colors;
    SpriteRenderer ren;
    TrailRenderer trail;
    Rigidbody rb;
    float baseForce = 500f;

    private void Awake()
    {
        if (GetComponent<Collider>() == null)
        {
            Debug.LogError(this.name + " has no collider!");
        }

        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        //launch(baseForce, playerBall);
    }

    public void launch(float force, Transform playerBall)
    {
        colors = ColorPallette.instance;
        ren = GetComponent<SpriteRenderer>();

        setColor(colors.getColorByHealth(health));

        //Vector2 dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        //Vector2 dir = Random.insideUnitCircle.normalized;

        Vector2 dir = playerBall.transform.position - transform.position;
        rb.AddRelativeForce(dir * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GM.instance.endGame();
        }
        else if (collision.transform.tag == "Wall")
        {
            health--;

            if(health <= 0)
            {
                GM.instance.incrementScore();
                GM.instance.playAudio(2, false);
                Destroy(this.gameObject);
            }
            else
            {
                setColor(colors.getColorByHealth(health));
                GM.instance.playAudio(1, false);
            }
        }
    }

    void setColor(Color newColor) 
    { 
        ren.color = newColor;
        trail.startColor = newColor;
    }
}
