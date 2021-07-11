using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerController : MonoBehaviour
{
    [SerializeField] GameObject demonPrefab;

	const float SUMMON_TIME = 2.5f;

    private float summonTimer = SUMMON_TIME;
    private Vector3 demonSpawnPos;
    private int summonCount = 0;

    private Animator animator;

    public bool canSummon = true;

    void Awake()
    {
        animator = GetComponent<Animator>();

        demonSpawnPos = transform.GetChild(0).transform.position;
        demonSpawnPos.y += 0.5f;
    }

    void Update()
    {
        if (canSummon) {
            TickSummonTime();
        }
    }

    void TickSummonTime()
    {
        summonTimer -= Time.deltaTime;

        if (summonTimer <= 0) {
            summonCount++;
            GameObject inst = Instantiate(demonPrefab, demonSpawnPos, Quaternion.identity);

            summonTimer = SUMMON_TIME + (1f * summonCount);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("SlapDetect")) {
            animator.SetBool("isSlapped", true);
            // play noise
        }
    }
}
