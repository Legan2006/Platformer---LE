using UnityEngine;

public class Projectiles : MonoBehaviour
{

    [SerializeField] float flightSpeed;

    [SerializeField] float Speed;






    void Update()
    {
        transform.position += transform.right * Time.deltaTime * flightSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }








}

