using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const float MAX_SURVIVAL_TIMER = 1f;
    const int SURVIVAL_POINTS = 2;

    [SerializeField] private Transform player;
    [SerializeField] private Text pointsLabel;

    private float survivalTimer = MAX_SURVIVAL_TIMER;

    private int points = 0;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        TickSurvivalTimer();
    }

    void TickSurvivalTimer()
    {
        survivalTimer -= Time.deltaTime;

        if (survivalTimer <= 0) {
            instance.AddPoints(SURVIVAL_POINTS);
            survivalTimer = MAX_SURVIVAL_TIMER;
        }
    }

    public Transform GetPlayer()
    {
        return instance.player;
    }

    public void AddPoints(int pts)
    {
        points += pts;
        pointsLabel.text = points.ToString();
    }
}
