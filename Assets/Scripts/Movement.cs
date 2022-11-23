using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 1.25f;

    bool alive = true;
    public float SpeedIncreasePerPoint = 0.1f;

    public GameObject[] Hearts;
    public int Life = 3;
    public int Damage = 1;



    private void FixedUpdate()
    {
        if (!alive) return;
            
        //player movement
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }


    public void isDead()
    {
        alive = false;
        Life = 0;
        Invoke("Restart", 2); //the game restarts once the player dies
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restart the game

    }

    public void TakeDamage()
    {
        Life -= Damage;
    }
    private void Update()
    {
        if (Life < 1)
        {
            Destroy(Hearts[0].gameObject);
            isDead();
        } 
        
        else if (Life < 2)
        {
            Destroy(Hearts[1].gameObject);
        }

        else if (Life < 3)
        {
            Destroy(Hearts[2].gameObject);
        } 


        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < - 5) //if the player's position is less than -5y then the player will die and the game will reset
        {
            isDead();
        }
    }
}
