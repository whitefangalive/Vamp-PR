using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadSegmentPrefab;
    public int numberOfSegments = 5;
    public float segmentLength = 10f;
    public float spawnOffset = 5f;

    private Transform player;
    [SerializeField] private GameObject[] roadSegments;

    private void Start()
    {
        player = Camera.main.transform; // Assuming the camera follows the player
        roadSegments = new GameObject[numberOfSegments];

        for (int i = 0; i < numberOfSegments; i++)
        {
            SpawnRoadSegment(i * segmentLength);
        }
    }

    private void Update()
    {
        // Check if the player has moved past the last road segment on the x-axis
        float playerX = player.position.x;
        float lastSegmentX = roadSegments[roadSegments.Length - 1].transform.position.x;

        if (playerX > lastSegmentX - spawnOffset)
        {
            DestroyRoadSegment(0);
            SpawnRoadSegment(lastSegmentX + segmentLength);
        }
    }

    private void SpawnRoadSegment(float xPosition)
    {
        GameObject newSegment = Instantiate(roadSegmentPrefab, new Vector3(xPosition, 0, 0), Quaternion.identity);
        if (roadSegments[roadSegments.Length - 1] != null)
        {
            // this is when the list is full
            roadSegments[roadSegments.Length - 1] = newSegment;

        }
        else
        {
            // here we need to find an empty slot to put the new road
            for (int i = 0; i < roadSegments.Length; i++)
            {
                if (roadSegments[i] == null)
                {
                    roadSegments[i] = newSegment;
                    return; // Break out of the loop after filling the first empty slot
                }
            }
        }
    }

    private void DestroyRoadSegment(int index)
    {
        Destroy(roadSegments[index]);
        for (int i = index; i < roadSegments.Length - 1; i++)
        {
            roadSegments[i] = roadSegments[i + 1];
        }
        roadSegments[roadSegments.Length - 1] = null;
    }
}
