using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Throwing : MonoBehaviour
{
  
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    private GameObject objectToThrow;
    public GameObject objectToThrow1;
    public GameObject objectToThrow2;   
    public GameObject objectToThrow3;
    public GameObject objectToThrow4;
    public GameObject objectToThrow5;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        objectToThrow = objectToThrow1;
        readyToThrow = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0){
            Throw();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            objectToThrow = objectToThrow1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            objectToThrow = objectToThrow2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            objectToThrow = objectToThrow3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            objectToThrow = objectToThrow4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            objectToThrow = objectToThrow5;
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        //Create object that will be thrown
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //Calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        //Add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //Implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
