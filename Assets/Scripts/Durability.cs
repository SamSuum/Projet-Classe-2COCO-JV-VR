using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    [SerializeField] private float HP = 3;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Target"))
        {
            if (HP > 0)
            {
                HP--;
                Debug.Log("Used");
            }
            else Destroy(gameObject);
        }
    }
}
