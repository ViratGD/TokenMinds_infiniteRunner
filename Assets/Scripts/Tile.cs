using UnityEngine;

public class Tile : MonoBehaviour
{
    TileSpawner GroundSpawner;
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject Coin;
    public int CoinsToSpawn = 5;
    private void Start()
    {
        GroundSpawner = GameObject.FindObjectOfType<TileSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        GroundSpawner.SpawnTile(true);
        Destroy(gameObject, 2); 
    }

    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5); //spawns the obstacles randomly based on order of the children of the object which are set as predefined spawn points.
        Transform SpawnPoint = transform.GetChild(obstacleSpawnIndex).transform; //randomly chooses the position to spawn the obstacles

        Instantiate(Obstacle, SpawnPoint.position, Quaternion.identity, transform); //spawns obstacles

    }

    public void SpawnCoins()
    {
        
        for (int i = 0; i < CoinsToSpawn; i++) //spawns a certain amount of coins from a predifined variable
        {
           GameObject temp = Instantiate(Coin, transform);
           temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); //randomizes coin spawn

        }

        Vector3 GetRandomPointInCollider(Collider collider) //gets a random point in the tile collider to spawn the coin and outputs it as a vector3
        {
            Vector3 point = new Vector3
                (
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );

            if (point != collider.ClosestPoint(point))
            {
                point = GetRandomPointInCollider(collider);
            }


            point.y = 1; //y is set to 1 so the coins always spawn above the ground tile.
            return point;
        }
    }

}
