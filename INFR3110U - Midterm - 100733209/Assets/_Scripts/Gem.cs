using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    //similar to the coin learned in class only with additional points added
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(5);
            Destroy(gameObject);
        }
    }
}
