using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
public class FishSpawner : MonoBehaviour
{
    public float fishPosY = -0.17f;
    public FishAI fishPrefab;

    public int minFishPerBatch = 3;
    public int maxFishPerBatch = 6;


    public float minSpawnInterval = 10f;
    public float maxSpawnInterval = 20f;

    public float spawnBatchRadius = 4f;

    public void Start()
    {
        StartCoroutine(SpawnFish());
    }
    private IEnumerator SpawnFish()
    {
        while (true)
        {
            GameObject[] fishInPond;
            fishInPond = GameObject.FindGameObjectsWithTag("Fish");
            if (fishInPond.Length <= 1)
            {
                int fishToSpawn = Random.Range(minFishPerBatch, maxFishPerBatch);
                for (int i = 0; i < fishToSpawn; i++)
                {
                    Vector3 spawnOffset = Random.insideUnitSphere * spawnBatchRadius;
                    Vector3 spawnPosition = (Vector3)gameObject.transform.position + spawnOffset;
                    spawnPosition.y = fishPosY;

                    FishAI newFish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
                }
            }
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);
        }
    }
}
