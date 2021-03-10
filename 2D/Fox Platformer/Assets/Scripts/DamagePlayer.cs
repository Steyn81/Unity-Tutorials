using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Hit");

            //Basic way
            //FindObjectOfType<PlayerHealthController>().DealDamage(); 

            //Adv way - create a singleton of PlayerHealthController. Don't need to search all objects for script
            //Better for performance
            PlayerHealthController.instance.DealDamage(); 

        }
        
    }
}
