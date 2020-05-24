using UnityEngine;

public class portalChecker : MonoBehaviour
{

    public portalChecker otherPortal;
    public bool receiving = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!receiving)
        {
            otherPortal.receiving = true;
            coll.gameObject.transform.position = otherPortal.gameObject.transform.position;
        }

        receiving = false;
    }
}