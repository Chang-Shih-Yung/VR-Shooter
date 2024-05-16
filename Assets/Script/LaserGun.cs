using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public void LeserGunFired()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Asteroid"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        
    }
}
