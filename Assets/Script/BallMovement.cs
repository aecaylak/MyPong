using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static BallMovement Instance { get; private set; } //bu scripti unity uzerinden baska scriptlerle erisilebilir yaptık
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float speed;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _rigidbody2D.AddForce(Vector2.down * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Racket"))
        {
            var directionH = (transform.position.x - collision.transform.position.x); //0,5, -0,5 arası değer verecek
            _rigidbody2D.AddForce(Vector2.right.normalized * speed * directionH); // normalized 0-1 arası değer verdirir.
        }
    }
}
