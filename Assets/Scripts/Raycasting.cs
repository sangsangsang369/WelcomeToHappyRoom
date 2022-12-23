using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    GameObject hitObj;
    [SerializeField]
    Color hitTexture;
    Color[] hitTextures = new Color[20];
    public float distance = 3000f;
    
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
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.grey;
                    hit.transform.gameObject.tag = "AntiRaycast";
                    hitTexture = Color.gray;
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


    public void Raycast_forMerge(int layer)
    {   
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
        if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag != "AntiRaycast" && hit.transform.gameObject.layer == layer)
        {
            if(hitObj == null)
            {
                if(hit.transform.gameObject.tag == "MeshParts")
                { 
                    hitObj = hit.transform.gameObject.transform.parent.gameObject;
                    for(int i = 0; i < hit.transform.gameObject.transform.parent.childCount; i++)
                    {
                        hitTextures[i] = hit.transform.gameObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color;
                        hit.transform.gameObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                }
                else
                {
                    hitObj = hit.transform.gameObject;
                    hitTexture = hit.transform.gameObject.GetComponent<MeshRenderer>().material.color;
                    hitObj.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
            }

            else if(hitObj != hit.transform.gameObject)
            {
                if(hitObj.tag == "MeshParts")
                {
                    if(hit.transform.gameObject.tag == "MeshParts")
                    {
                        hitObj = hit.transform.gameObject.transform.parent.gameObject;
                    }
                    else
                    {
                        for(int i = 0; i < hitObj.transform.childCount; i++)
                        {
                            hitObj.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = hitTextures[i];
                        }
                        hitObj = hit.transform.gameObject;
                        hitTexture = hit.transform.gameObject.GetComponent<MeshRenderer>().material.color;
                        hitObj.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }
                }
                else
                {
                    if(hit.transform.gameObject.tag == "MeshParts")
                    { 
                        hitObj.GetComponent<MeshRenderer>().material.color = hitTexture;
                        hitObj = hit.transform.gameObject.transform.parent.gameObject;
                        for(int i = 0; i < hit.transform.gameObject.transform.parent.childCount; i++)
                        {
                            hitTextures[i] = hit.transform.gameObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color;
                            hit.transform.gameObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                        }
                    }
                    else
                    {
                        hitObj.GetComponent<MeshRenderer>().material.color = hitTexture;
                        hitObj = hit.transform.gameObject;
                        hitTexture = hit.transform.gameObject.GetComponent<MeshRenderer>().material.color;
                        hitObj.GetComponent<MeshRenderer>().material.color = Color.blue;
                    }   
                }
                
            }

            else if(hitObj == hit.transform.gameObject)
            {
                if(hit.transform.gameObject.tag == "MeshParts")
                {
                    hitObj = hit.transform.gameObject.transform.parent.gameObject;
                }
                else
                {
                    hitObj = hit.transform.gameObject;
                }
            }
            
            if(Input.GetMouseButtonDown(0))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
                hit.transform.gameObject.tag = "AntiRaycast";
                hitTexture = Color.gray;
            }
        }
    }
    
    
}
