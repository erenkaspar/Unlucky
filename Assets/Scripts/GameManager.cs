using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreTextUI;
    public PerfectScript perfectScript;
    public bool gameActive = true;
    public GameObject gameOverPanel;

    public GameObject scoreCircle;
    public Transform centerObject;
    float circleRadius = -1.66f;

    public float totalTime = 30f;
    public Text timeTextUI;

    public Events events;
    public Text unlockKeyCodeText;
    public GameObject unlockKeyCodeEventPanel;

    void Start() {
        events.DefaultSettings();

        SpawnScore();
    }

    void Update() {
        scoreTextUI.text = score.ToString();

        if (gameActive) {
            if (totalTime >= 0) {
                totalTime -= Time.deltaTime;
                timeTextUI.text = totalTime.ToString("0");
            } else {
             GameOver();
            }
        }

        if (events.isUnlockText) {
            unlockKeyCodeEventPanel.SetActive(true);
            switch (events.unlockKeyCode) {
                case KeyCode.W:
                    unlockKeyCodeText.text = "W";
                    break;
                case KeyCode.A:
                    unlockKeyCodeText.text = "A";
                    break;
                case KeyCode.S:
                    unlockKeyCodeText.text = "S";
                    break;
                case KeyCode.D:
                    unlockKeyCodeText.text = "D";
                    break;
            }
        }
    }

    public void AddScore() {

        if (perfectScript.perfectArea) {
            DestroyScore();
            score += 1;
            NewLevel();
            score += 1;
            NewLevel();

        } else {
            DestroyScore();
            score += 1;
            NewLevel();
        }

    }
    void DestroyScore() {
        Destroy(GameObject.FindWithTag("Score"));
    }


    void NewLevel() {
        if (score % 20 == 0) {
            totalTime = 30;

            events.DefaultSettings();
            
            int randomEvent = UnityEngine.Random.Range(1, 4);
            switch (randomEvent) {
                case 1:
                    events.isRandomSpeedEvent = true;
                    break;
                case 2:
                    events.isRandomColorEvent = true;
                    break;
                case 3:
                    events.isUnlockEvent = true;
                    break;
            }
            
            
        }
    }

    public void GameOver() {
        events.DefaultSettings();
        gameOverPanel.SetActive(true);
        gameActive = false;
    }



    private Vector3 RandomScoreSpawn(Vector3 center, float radius) {
        float angle = UnityEngine.Random.Range(0f, 360f);

        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f);

        return center + direction * radius;
    }

    public void SpawnScore() {
        Vector3 randomPoint = RandomScoreSpawn(centerObject.transform.position, circleRadius);

        Instantiate(scoreCircle, randomPoint, Quaternion.identity);
    }

}
