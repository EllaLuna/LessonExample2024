using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float waitTimeToSpawn = 1f;
    [SerializeField] int amountToSpawn;
    [SerializeField] GameObject minMarker;
    [SerializeField] GameObject maxMarker;
    [SerializeField] Vector2 waitTimeRandom = new Vector2(0, 0.6f);
    
    void Start()
    {
        if (prefabs == null)
            Debug.LogError("You are missing a prefab");
        if (waitTimeToSpawn == 0)
            Debug.LogError("Wait time is zero");
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            yield return new WaitForSeconds(waitTimeToSpawn - Random.Range(waitTimeRandom.x, waitTimeRandom.y));
            var position = new Vector2(Random.Range(minMarker.transform.position.x, maxMarker.transform.position.x), minMarker.transform.position.y);
            var randomIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomIndex], position, Quaternion.identity);
        }
    }
}
