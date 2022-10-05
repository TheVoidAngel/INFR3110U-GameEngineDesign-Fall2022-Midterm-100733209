using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision2)
    {

        if (collision2.collider.tag == "Enemy")
        {
            Destroy(collision2.gameObject);
        }
    }
}
