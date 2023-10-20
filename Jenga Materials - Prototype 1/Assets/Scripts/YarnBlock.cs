using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody colliderRb = collision.gameObject.GetComponent<Rigidbody>(); 
        Rigidbody selfRb = GetComponent<Rigidbody>();

        if (colliderRb != null && selfRb != null) 
        {
            colliderRb.velocity = Vector3.zero;
            colliderRb.angularVelocity = Vector3.zero; 
            selfRb.velocity = Vector3.zero;
            selfRb.angularVelocity = Vector3.zero;
        }
    }

}
