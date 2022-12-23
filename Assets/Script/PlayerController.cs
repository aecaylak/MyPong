using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitH = 2.2f;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float aiSpeed;
    private void Update()
    {
        Vector3 newPosition = transform.position;
        
        if (isPlayer)
        {
            var input = Input.GetAxis("Horizontal");
            newPosition = transform.position + (Vector3.right * (input * speed * Time.deltaTime)); // Vector3.right: Shorthand for writing Vector3(1, 0, 0)

        }
        else
        {
            var ai = Mathf.Lerp(newPosition.x, BallMovement.Instance.transform.position.x, aiSpeed * Time.deltaTime); //a ile b arasını t kadar bölüm bölüm gidecek
            newPosition.x = ai;
        }
        
        
        newPosition.x = Mathf.Clamp(newPosition.x, -limitH, limitH); //Mathf.Clamp: The float result between the minimum and maximum values.
        transform.position = newPosition;
    }
}
