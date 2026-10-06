using UnityEngine;

public class EnemyGolem : MonoBehaviour
{


    Rigidbody2D golemBox;
    void Start()
    {
        golemBox = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDestruction();
    }

    private void EnemyDestruction()
    {
        if (golemBox.IsTouchingLayers(LayerMask.GetMask("Projectiles")))
        {
            Destroy(gameObject);
        }

    }



}
