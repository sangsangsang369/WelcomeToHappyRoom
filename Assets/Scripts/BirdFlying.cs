using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlying : MonoBehaviour
{
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 7;

    private void Update() 
    {
        if(this.gameObject.transform.position.x < 1120)
        {
            moveVelocity = new Vector3(+18f,+2f,0);
            this.gameObject.transform.position +=moveVelocity * moveSpeed * Time.deltaTime;
        }   
    }
}
