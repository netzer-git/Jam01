using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPref;
    public KeyCode fireKey;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey)){
            // Instantiate(bulletPref, firePoint.position, firePoint.rotation);
        }
    }
}
