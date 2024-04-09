//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Weapon : MonoBehaviour
//{
//    [SerializeField] GameObject ammo;
//    [SerializeField] Transform emission;
//    [SerializeField] AudioSource audioSource;

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            audioSource.Play();
//            Instantiate(ammo, transform.position, emission.rotation);
//        }
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emission;
    [SerializeField] float fireRate;
    [SerializeField] AudioSource audioSource;

    bool fireReady = true;

    void Update()
    {
        if (fireReady && Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            Instantiate(ammo, emission.position, emission.rotation);
            fireReady = false;
            StartCoroutine(FireTimer(fireRate));
        }
    }

    IEnumerator FireTimer(float time)
    {
        yield return new WaitForSeconds(time);
        fireReady = true;
    }
}