using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerController : MonoBehaviour
{
    [SerializeField] GameObject demonPrefab;

	const float SUMMON_TIME = 2.5f;

    private float summonTimer = SUMMON_TIME;
    private Vector3 demonSpawnPos;

    void Awake()
    {
        demonSpawnPos = transform.GetChild(0).transform.position;
        demonSpawnPos.y += 0.5f;
    }

    void Update()
    {
        TickSummonTime();
    }

    void TickSummonTime()
    {
        summonTimer -= Time.deltaTime;

        if (summonTimer <= 0) {
            GameObject inst = Instantiate(demonPrefab, demonSpawnPos, Quaternion.identity);

            summonTimer = SUMMON_TIME + 1f;     // off set for demon rising animation
        }
    }
}
