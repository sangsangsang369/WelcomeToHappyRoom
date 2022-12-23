using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMoving : MonoBehaviour
{
    public bool leftMove = false;
    public bool rightMove = false;
    Vector3 moveVelocity = Vector3.zero;
    float moveSpeed = 13;

    private void Update() 
    {
        if(leftMove && this.gameObject.transform.position.x < 1120)
        {
            moveVelocity = new Vector3(+10f,0,0);
            this.gameObject.transform.position +=moveVelocity * moveSpeed * Time.deltaTime;
            
        }    
        if(rightMove && this.gameObject.transform.position.x > -42)
        {
            moveVelocity = new Vector3(-10f,0,0);
            this.gameObject.transform.position +=moveVelocity * moveSpeed * Time.deltaTime;
            
        }    
    }

     public void LeftBtnDown()
    {
        leftMove = true;
        this.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
    }   

    public void LeftBtnUp()
    {
        leftMove = false;
        this.gameObject.GetComponent<Animator>().SetBool("isMoving", false);
    }  

    public void RightBtnDown()
    {
        rightMove = true;
        this.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
    }

    public void RightBtnUp()
    {
        rightMove = false;
        this.gameObject.GetComponent<Animator>().SetBool("isMoving", false);
    }
}
