using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject Tile;
    Vector3 nextSpawnPoint;
    public int NumberOfTilesToSpawn = 10;
    public int EmptyTiles = 1;

    public void SpawnTile(bool SpawnItems)

    {
       GameObject temp = Instantiate(Tile, nextSpawnPoint, Quaternion.identity); //spawns a tile from the precreated tile in a temp variable
       nextSpawnPoint = temp.transform.GetChild(1).transform.position; //gets the position of the next tile spawn
       
       if (SpawnItems)
        {
            temp.GetComponent<Tile>().SpawnObstacle();
            temp.GetComponent<Tile>().SpawnCoins();

        }
    }
    void Start()
    {
        for (int i = 0; i < NumberOfTilesToSpawn; i++) //loops the number of tiles spawned ahead of the player
        {
            if (i < EmptyTiles) //number of empty tiles before tiles with obstacles spawn
            {
                SpawnTile(false); //spawns coins and obstacles after the 3rd tile has spawned
            }
            
            else SpawnTile(true); //spawns tile
        }
    }
}
