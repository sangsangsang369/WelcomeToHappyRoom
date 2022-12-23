using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject alarmParent, readyPage, mainPage, endingPage, fadeOut1, fadeOut2;
    [SerializeField]
    Camera mainCam;

    public void SelectMenuOn()
    {
        if(!this.gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void SelectOne(GameObject alarm)
    {
        for(int i = 0; i < alarmParent.transform.childCount; i++)
        {
            alarmParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        alarm.SetActive(true);
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void ReadyToMain()
    {
        readyPage.SetActive(false);
    }

    public void MainToEnding()
    {
        mainPage.SetActive(false);
        endingPage.SetActive(true);
        mainCam.transform.position = new Vector3(7.3f, 5.53f, -5.17f);
        //원래 카메라 위치 5.07, 5.07 ,-3
    }
    public void StartBtnFunc()
    {
        fadeOut1.SetActive(true);
        fadeOut1.GetComponent<Animator>().SetBool("start", true);
    }

    public void DoneBtnFunc()
    {
        fadeOut2.SetActive(true);
        fadeOut2.GetComponent<Animator>().SetBool("done", true);
    }

    public void HomeBtnFunc()
    {
        fadeOut2.SetActive(true);
        fadeOut2.GetComponent<Animator>().SetBool("home", true);
    }

    public void EndingToReady()
    {
        endingPage.SetActive(false);
        readyPage.SetActive(true);
    }
}
