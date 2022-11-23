using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.GetComponent<Obstacle>() != null) //makes sure the coins dont spawn inside the obstacles

        {
            Destroy(gameObject);
        }
        
        if (other.gameObject.name != "Player") //returns mull if the anything other than the player interacts with the coin
        {
            return;
        }

        GameManager.inst.IncrementScore(); //adds +1 to the score for every coin that is picked up by the player

        Destroy(gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime); //rotates the coins 90° every frame
    }
}
