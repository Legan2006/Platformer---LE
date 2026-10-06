using UnityEngine;

public class EnemyOrc : MonoBehaviour
{


    Rigidbody2D enemyOrc;

    CapsuleCollider2D orcBody;

    [SerializeField] float walkSpeed;

    [SerializeField] float runSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyOrc = GetComponent<Rigidbody2D>();

        orcBody = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDestruction();
        if (IsFacingRight())
        {
            enemyOrc.linearVelocity = new Vector2(walkSpeed, 0);
        }
        else
        {
            enemyOrc.linearVelocity = new Vector2(-walkSpeed, 0);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyOrc.linearVelocity.x)), 1f);
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void EnemyDestruction()
    {
        if (enemyOrc.IsTouchingLayers(LayerMask.GetMask("Projectiles")))
        {
            Destroy(gameObject);
        }

    }



}