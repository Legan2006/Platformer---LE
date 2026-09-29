using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyBlob;

    [SerializeField] private float moveSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyBlob =  GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            enemyBlob.linearVelocity = new Vector2(moveSpeed, 0);
        }
        else {
            enemyBlob.linearVelocity = new Vector2(-moveSpeed, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyBlob.linearVelocity.x)),1f);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

}
