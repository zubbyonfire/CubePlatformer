using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {

    //Child the Player while they collide with the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
        {
            if (collision.GetComponent<IPlatform>() != null)
            {
                collision.GetComponent<IPlatform>().OnPlatform(true);
                collision.transform.parent = this.gameObject.transform;
            }
        }
    }

    //De-Child the player once they exit the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object")
        {
            if (collision.GetComponent<IPlatform>() != null)
            {
                collision.GetComponent<IPlatform>().OnPlatform(false);
                collision.gameObject.transform.parent = null;
            } 
        }
    }
}
