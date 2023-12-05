using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject key;
    public GameObject keyCol;
    public Transform pickUpPosition;
    private bool keyInRange = false;
    public bool onPlayer = false;
    private Transform previousPos;

    private void Update()
    {
        KeyInteraction checkKey = this.GetComponent<KeyInteraction>();
        if (checkKey.keyUsed)
        {
            onPlayer = false;
        }

        if (keyInRange && Input.GetKey(KeyCode.E))
        {
            //key.transform.position = previousPos.position;
            keyCol.GetComponent<BoxCollider>().enabled = false;
            onPlayer = true;
           // keyCol.GetComponent<Rigidbody>().isKinematic = true;
            
        }
        if (onPlayer)
        {
            key.transform.position = pickUpPosition.position;
            
        }
        if (onPlayer && Input.GetKey(KeyCode.Q))
        {
            keyCol.GetComponent<BoxCollider>().enabled = true;
            key.transform.position = pickUpPosition.position;
           // keyCol.GetComponent<Rigidbody>().isKinematic = false;
            onPlayer = false;
        }
        Debug.Log(onPlayer);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "key")
        {
            keyInRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "key")
        {
            keyInRange = false;
        }
    }
}
