using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CollectbleBattery : MonoBehaviour
{
    Animator pickedUp;

    public Image EButton;
    public Boolean AllowPickup;

    
    void Start()
    {
        pickedUp = GetComponent<Animator>();
        EButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowPickup && Input.GetButtonDown("Interact"))
        {
            pickUp();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EButton.gameObject.SetActive(true);
            AllowPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EButton.gameObject.SetActive(false);
            AllowPickup = false;
        }
    }

    private void pickUp()
    {
        pickedUp.SetBool("IsPickedUp", true);
        Destroy(gameObject, 0.7f);
    }
}
