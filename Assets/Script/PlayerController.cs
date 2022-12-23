using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitH = 2.2f;
    [SerializeField] private bool isPlayer;
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
            var ai = BallMovement.Instance.transform.position.x;
            newPosition.x = ai;
        }
        
        
        newPosition.x = Mathf.Clamp(newPosition.x, -limitH, limitH); //Mathf.Clamp: The float result between the minimum and maximum values.
        transform.position = newPosition;
    }
}
