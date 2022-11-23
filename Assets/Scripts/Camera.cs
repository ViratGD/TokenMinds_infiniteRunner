using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform Player;
    Vector3 offset;


    void Start()
    {
        offset = transform.position - Player.position;
    }

    void Update()
    {
        Vector3 targetPosition = Player.position + offset; //moves the camera to follow the player
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
