using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject summonerPrefab;

	const float PLAY_AREA_WIDTH = 6;
    const float PLAY_AREA_HEIGHT = 3;
    
    const float MIN_SPAWN_TIME = 3f;
    const float MAX_SPAWN_TIME = 8f;

    private float spawnCooldown;
    private float spawnTimer;

    void Awake()
    {
        spawnCooldown = 1f;
        spawnTimer = spawnCooldown;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0) {
            spawnCooldown = Random.Range(MIN_SPAWN_TIME, MAX_SPAWN_TIME);
            spawnTimer = spawnCooldown;

            Vector3 spawnPos = new Vector3(
                Random.Range(-PLAY_AREA_WIDTH, PLAY_AREA_WIDTH),
                Random.Range(-PLAY_AREA_HEIGHT, PLAY_AREA_HEIGHT),
                0
            );

            GameObject inst = Instantiate(summonerPrefab, spawnPos, Quaternion.identity);

            if (Random.Range(0f, 1f) > 0.5f) {
                Debug.Log("flip");
                inst.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
    }
}
