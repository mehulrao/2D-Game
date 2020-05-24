using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCollide : MonoBehaviour
{

    public deathCollide endLocation;
    public bool receiving = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!receiving)
        {
            endLocation.receiving = true;
            coll.gameObject.transform.position = endLocation.gameObject.transform.position;
        }

        receiving = false;
    }
}
