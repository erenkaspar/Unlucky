using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform centerObject;
    public float rotationSpeed = 150f;
    bool forwardRotation = true;
    bool isInTriggerArea = false;

    public GameManager gameManager;
    public Events events;

    void Update()
    {
        if (Input.GetKeyDown(events.unlockKeyCode)) {
            events.isLock = false;
            events.isUnlockText = false;
            gameManager.unlockKeyCodeEventPanel.SetActive(false);
        }

        if (gameManager.gameActive) {
            if (Input.GetKeyDown(KeyCode.Space) && events.isLock == false) {
                if (isInTriggerArea) {
                    forwardRotation = !forwardRotation;
                    gameManager.AddScore();
                    if (events.isRandomSpeedEvent) {
                        events.RandomSpeedEvent();
                    } else if (events.isRandomColorEvent) {
                        events.RandomColorEvent();
                    } else if (events.isUnlockEvent) {
                        events.UnlockEvent();
                    }
                    gameManager.SpawnScore();
                } else {
                    gameManager.GameOver();
                }
            }

            if (forwardRotation) {
                transform.RotateAround(centerObject.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            } else {
                transform.RotateAround(centerObject.position, Vector3.back, rotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Score")) {
            isInTriggerArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Score")) {
            isInTriggerArea = false;
        }
    }

}
