using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject doorClosed;
    public GameObject doorOpen;
    private bool rangeInDoor;
    private bool itemOnPlayer;
    public GameObject key;
    public Transform lockerPos;
    public bool keyUsed = false;

    private void Start()
    {

    }
    private void Update()
    {
        PickUpItem itemPlayer = this.GetComponent<PickUpItem>();
        itemOnPlayer = itemPlayer.onPlayer;

        if (rangeInDoor && Input.GetKey(KeyCode.E) && itemOnPlayer)
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(true);
            keyUsed = true;
            key.transform.position = lockerPos.position;
            
            //itemPlayer.onPlayer = false;
            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "locker")
        {
            rangeInDoor = true;

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "locker")
        {
            rangeInDoor = false;
        }
    }
}
