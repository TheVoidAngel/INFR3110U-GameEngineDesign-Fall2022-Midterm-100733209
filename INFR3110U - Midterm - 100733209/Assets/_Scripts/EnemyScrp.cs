using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScrp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            ScoreManager.instance.ChangeScore2(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
