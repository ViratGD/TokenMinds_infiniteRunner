using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Movement playerMovement;
    public GameObject Explosion;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<Movement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMovement.TakeDamage();
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation); //spawn explosion animation

        }
        //death on collision with obstacles
    }

}
