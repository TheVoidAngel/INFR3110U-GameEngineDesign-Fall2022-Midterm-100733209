using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
