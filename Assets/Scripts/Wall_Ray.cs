using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Ray : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    GameObject hitObj;
    [SerializeField]
    Color hitTexture;
    [SerializeField]
    Material white;
    Color[] hitTextures = new Color[20];
    public float distance = 3000f;

    void Update()
    {
        Raycast_forMerge(6);   
    }

    public void Raycast_forMerge(int layer)
    {   
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);

        if(Physics.Raycast(ray, out hit) 
        && hit.transform.gameObject.tag != "AntiRaycast" )
        {
            if(hit.transform.gameObject.layer == layer)
            {
                if(hitObj == null)
                {
                    hitObj = hit.transform.gameObject.transform.parent.gameObject;
                    hitTexture = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                    for(int i = 0; i < hitObj.transform.childCount; i++)
                    {
                        hitObj.transform.GetChild(i).GetComponent<Renderer>().material.color = Color.blue;
                    }
                }

                else if(hitObj != hit.transform.gameObject.transform.parent.gameObject)
                {
                    for(int i = 0; i < hitObj.transform.childCount; i++)
                    {
                        hitObj.transform.GetChild(i).GetComponent<Renderer>().material.color = hitTexture;
                    }
                    hitObj = hit.transform.gameObject.transform.parent.gameObject;
                    hitTexture = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                    for(int i = 0; i < hitObj.transform.childCount; i++)
                    {
                        hitObj.transform.GetChild(i).GetComponent<Renderer>().material.color = Color.blue;
                    }
                }

                else if(hitObj == hit.transform.gameObject.transform.parent.gameObject)
                {}
                
                if(Input.GetMouseButtonDown(0))
                {
                    for(int i = 0; i < hitObj.transform.childCount; i++)
                    {
                        hitObj.transform.GetChild(i).GetComponent<Renderer>().material = white;
                        hitObj.transform.GetChild(i).gameObject.tag = "AntiRaycast";
                    }
                    hitTexture = Color.white;
                }
            }
            else
            {
                if(hitObj)
                {
                    for(int i = 0; i < hitObj.transform.childCount; i++)
                    {
                        hitObj.transform.GetChild(i).GetComponent<Renderer>().material.color = hitTexture;
                    }
                    hitObj = null;
                }
                
            }
        }
    }
}
