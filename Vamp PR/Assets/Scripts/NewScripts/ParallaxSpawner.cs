using UnityEngine;

public class ParallaxSpawner : MonoBehaviour
{
    public GameObject parallaxLayerPrefab;
    public int numberOfSegments = 5;
    public float segmentLength = 10f;
    public float spawnOffset = 5f;

    private Transform player;
    [SerializeField] private GameObject[] parallaxSegments;

    private void Start()
    {
        player = Camera.main.transform; // Assuming the camera follows the player
        parallaxSegments = new GameObject[numberOfSegments];

        for (int i = 0; i < numberOfSegments; i++)
        {
            SpawnParallaxSegment(i * segmentLength);
        }
    }

    private void Update()
    {
        // Check if the player has moved past the last road segment on the x-axis
        float playerX = player.position.x;
        float lastSegmentX = parallaxSegments[parallaxSegments.Length - 1].transform.position.x;

        if (playerX > lastSegmentX - spawnOffset)
        {
            DestroyParallaxSegment(0);
            SpawnParallaxSegment(lastSegmentX + segmentLength);
        }
    }

    private void SpawnParallaxSegment(float xPosition)
    {
        GameObject newSegment = Instantiate(parallaxLayerPrefab, new Vector3(xPosition, transform.position.y, 0), Quaternion.identity);
        newSegment.transform.SetParent(this.transform);
        if (parallaxSegments[parallaxSegments.Length - 1] != null)
        {
            // this is when the list is full
            parallaxSegments[parallaxSegments.Length - 1] = newSegment;

        }
        else
        {
            // here we need to find an empty slot to put the new road
            for (int i = 0; i < parallaxSegments.Length; i++)
            {
                if (parallaxSegments[i] == null)
                {
                    parallaxSegments[i] = newSegment;
                    return; // Break out of the loop after filling the first empty slot
                }
            }
        }
    }

    private void DestroyParallaxSegment(int index)
    {
        Destroy(parallaxSegments[index]);
        for (int i = index; i < parallaxSegments.Length - 1; i++)
        {
            parallaxSegments[i] = parallaxSegments[i + 1];
        }
        parallaxSegments[parallaxSegments.Length - 1] = null;
    }
}
