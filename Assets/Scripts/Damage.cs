using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float HP = 3;    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Axe"))
        {
            if (HP > 0)
            {
                HP--;
                Debug.Log("hit");
            }
            else Destroy(gameObject);
        }
    }
}
