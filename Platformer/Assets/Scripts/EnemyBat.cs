using System;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{




    [SerializeField] float flightSpeed;

    private GameObject Player;

    Rigidbody2D batBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");

        batBox = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDestruction();
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, flightSpeed * Time.deltaTime);
        if (IsFacingRight())
        {
           // Debug.Log("right");

        }
        else
        {
           // Debug.Log("left");
        }
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (batBox.linearVelocity.x >= 0)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(batBox.linearVelocity.x)), 1f);
        }

    }

    private void EnemyDestruction()
    {
        if (batBox.IsTouchingLayers(LayerMask.GetMask("Projectiles"))){
            Destroy(gameObject);
        }

    }



    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }


}
