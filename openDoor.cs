using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{

    public GameObject doorOpen;
    public GameObject doorClose;
    private bool isDoorOpen = false;
    private bool isNearPlayer = false;
    
    void Update()
    {

        if (isNearPlayer && Input.GetKey(KeyCode.E))
        {
                if (!isDoorOpen)
                {
                    doorClose.gameObject.SetActive(false);
                    doorOpen.gameObject.SetActive(true);
                }
               /* else
                {
                    doorClose.gameObject.SetActive(true);
                    doorOpen.gameObject.SetActive(false);
            } */
        }

        if (doorClose.gameObject.activeInHierarchy)
        {
            isDoorOpen = false;
        }
        else
        {
            isDoorOpen = true;
        }

    }
     
        
public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isNearPlayer = true;
            Debug.Log("door near player");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isNearPlayer = false;
            Debug.Log("door not near player");
        }
    }

}
