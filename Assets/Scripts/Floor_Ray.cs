using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Ray : MonoBehaviour
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
        Raycast(7);   
    }

    public void Raycast(int layer)
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
                    hitObj = hit.transform.gameObject;
                    hitTexture = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                    hitObj.GetComponent<Renderer>().material.color = Color.blue;
                }

                else if(hitObj != hit.transform.gameObject)
                {
                    hitObj.GetComponent<Renderer>().material.color = hitTexture;
                    hitObj = hit.transform.gameObject;
                    hitTexture = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                    hitObj.GetComponent<Renderer>().material.color = Color.blue;
                }

                else if(hitObj == hit.transform.gameObject)
                {}
                
                if(Input.GetMouseButtonDown(0))
                {
                    hit.transform.gameObject.GetComponent<Renderer>().material = white;
                    hit.transform.gameObject.tag = "AntiRaycast";
                    hitTexture = Color.white;
                }
            }
            else
            {
                if(hitObj)
                {
                    hitObj.GetComponent<Renderer>().material.color = hitTexture;
                    hitObj = null;
                }
                
            }
        }
    }

}
