using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject player;
    public GameObject pointCubePrefab; // Assign your point cube prefab here
    public float spawnThreshold = 10.0f;
    public int maxPointsPerFloor = 10; // Maximum number of points that can spawn on a single floor
    public float laneWidth = 2.33f; // Adjust this to match the width of your lanes
    public float cheeseSpacing = 3.0f; // Fixed space between each cheese
    public int minCheeseCount = 2; // Minimum number of cheeses
    public float floorLength = 30.0f; // Length of the floor
    public float beginCheeseProbability = 0.8f; // Probability of a cheese appearing at the beginning of the floor
    public float consecutiveCheeseProbability = 0.7f; // Probability of the next item being a cheese if there is a cheese
    public float nonCheeseProbability = 0.9f; // Probability of the next item not being a cheese if there is no cheese
    private Vector3 nextSpawnPoint;

    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, 30);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, nextSpawnPoint) < spawnThreshold)
        {
            SpawnFloor();
        }
    }

    void SpawnFloor()
    {
        GameObject newFloor = Instantiate(floorPrefab, nextSpawnPoint, Quaternion.identity);

        nextSpawnPoint += new Vector3(0, 0, 30);

        SpawnPoints(newFloor);
    }

    void SpawnPoints(GameObject floor)
    {
        int nbrCheese = Mathf.FloorToInt(floorLength / cheeseSpacing); // Maximum number of cheeses based on floor length

        float[] xPositions = new float[] { -laneWidth, 0.0f, laneWidth }; // Possible x positions for the cheese 

        bool previousItemWasCheese = false; // Flag to track if the previous item was a cheese

        for (int i = 0; i < nbrCheese; i++)
        {
            float x;
            float y = 1;
            float z = floor.transform.position.z + (i * cheeseSpacing); // Calculate the z position based on cheese spacing
            
            if (i == 0 && Random.value <= beginCheeseProbability)
            {
                x = xPositions[Random.Range(0, xPositions.Length)]; // Randomly choose one of the x positions
                previousItemWasCheese = true;
                Vector3 pointPosition = new Vector3(x, y, z);
                Instantiate(pointCubePrefab, pointPosition, Quaternion.identity);
            }
            else if (previousItemWasCheese && Random.value <= consecutiveCheeseProbability)
            {
                x = xPositions[Random.Range(0, xPositions.Length)];
                previousItemWasCheese = true;
                Vector3 pointPosition = new Vector3(x, y, z);
                Instantiate(pointCubePrefab, pointPosition, Quaternion.identity);
            }
            else
            {
                previousItemWasCheese = false;
            }

            

            

            
        }
    }


}
