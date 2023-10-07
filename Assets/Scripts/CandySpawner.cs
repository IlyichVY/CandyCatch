using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;
    [SerializeField]
    float spawnInterval;

    float randomX;
    public GameObject[] Candies;
    
    public static CandySpawner instance;

    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCandies();
    }

    void SpawnCandy()
    {
        int randomIndex = Random.Range(0, Candies.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(Candies[randomIndex], randomPosition, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies() 
    {
        StartCoroutine("SpawnCandies");
    }
    
    public void StopSpawningCandies() 
    {
        StopCoroutine("SpawnCandies");
    }

}
