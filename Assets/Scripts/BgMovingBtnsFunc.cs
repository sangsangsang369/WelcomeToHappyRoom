using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovingBtnsFunc : MonoBehaviour
{
    BgMoving bgMoving;
    public GameObject bg;

    private void Start() 
    {
        bgMoving = FindObjectOfType<BgMoving>();    
    }

    public void LeftBtnDown()
    {
        bgMoving.leftMove = true;
        bg.GetComponent<Animator>().SetBool("isMoving", true);
    }   

    public void LeftBtnUp()
    {
        bgMoving.leftMove = false;
        bg.GetComponent<Animator>().SetBool("isMoving", false);
    }  

    public void RightBtnDown()
    {
        bgMoving.rightMove = true;
        bg.GetComponent<Animator>().SetBool("isMoving", true);
    }

    public void RightBtnUp()
    {
        bgMoving.rightMove = false;
        bg.GetComponent<Animator>().SetBool("isMoving", false);
    }
}
