using System.Collections;
using UnityEngine;

public class MosquitoSpawner : MonoBehaviour
{
    public GameObject mosquitoPrefab; // پریفب پشه
    public float spawnInterval = 1.5f; // فاصله بین اسپاون‌ها
    public float minX = -7f; // حداقل X برای اسپاون
    public float maxX = 7f;  // حداکثر X برای اسپاون
    public float spawnY = 6f; // ارتفاع اسپاون بالای صحنه

    void Start()
    {
        StartCoroutine(SpawnMosquitos());
    }

    IEnumerator SpawnMosquitos()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, spawnY);
            Instantiate(mosquitoPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
