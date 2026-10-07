using System;
using UnityEngine;

public class Lava : MonoBehaviour
{

    Rigidbody2D lavaBody;

    [SerializeField] float lavaSpeed;


    void Start()
    {
        lavaBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * lavaSpeed);
    }
}
