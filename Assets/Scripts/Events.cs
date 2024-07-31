using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Events : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer playerColor;
    public SpriteRenderer scoreColor;
    public GameManager gameManager;


    public float baseSpeed = 150f;

    //Eventler
    public bool isRandomSpeedEvent = false;
    public bool isRandomColorEvent = false;
    public bool isUnlockEvent = false;

    //Unlock Event
    public KeyCode unlockKeyCode;
    public bool isLock = false;
    public bool isUnlockText = false;

    public void RandomSpeedEvent() {
        float randomSpeed = Random.Range(baseSpeed, baseSpeed+100f);
        playerMovement.rotationSpeed = randomSpeed;
    }

    public void RandomColorEvent() {
        int randomTheme = Random.Range(1, 6);
        switch (randomTheme) {
            case 1:
                //RandomColorEvent - Black
                Color backgroundBlack = new Color(26 / 255f, 26 / 255f, 26 / 255f);
                Camera.main.backgroundColor = backgroundBlack;

                Color playerBlack = new Color(15 / 255f, 15 / 255f, 15 / 255);
                playerColor.color = playerBlack;

                Color scoreBlack = new Color(15 / 155f, 15 / 155f, 15 / 155f);
                scoreColor.color = scoreBlack;
                break;
            case 2:
                //RandomColorEvet - Green
                Color backgroundGreen = new Color(176 / 255f, 217 / 255f, 177 / 255f);
                Camera.main.backgroundColor = backgroundGreen;

                Color playerGreen = new Color(163 / 255f, 209 / 255f, 162 / 255f);
                playerColor.color = playerGreen;

                Color scoreGreen = new Color(208 / 255f, 231 / 255f, 210 / 255f);
                scoreColor.color = scoreGreen;
                break;
            case 3:
                //RandomColorEvet - Purple
                Color backgroundPurple = new Color(112 / 255f, 66 / 255f, 100 /255f);
                Camera.main.backgroundColor = backgroundPurple;

                Color playerPurple = new Color(122 / 255f, 68 / 255f, 106 / 255f);
                playerColor.color = playerPurple;

                Color scorePurple = new Color(153 / 255f, 132 / 255f, 147 / 255f);
                scoreColor.color = scorePurple;
                break;
            case 4:
                //RandomColorEvet - Red
                Color backgroundRed = new Color(160 / 255f, 21 / 255f, 62 / 255f);
                Camera.main.backgroundColor = backgroundRed;

                Color playerRed = new Color(160 / 255f, 21 / 255f, 62 / 255f);
                playerColor.color = playerRed;

                Color scoreRed = new Color(160 / 255f, 21 / 255f, 62 / 255f);
                scoreColor.color = scoreRed;
                break;
            case 5:
                //RandomColorEvet - Orange
                Color backgroundOrange = new Color(255 / 255f, 175 / 255f, 69 / 255f);
                Camera.main.backgroundColor = backgroundOrange;

                Color playerOrange = new Color(255 / 255f, 187 / 255f, 92 / 255f);
                playerColor.color = playerOrange;

                Color scoreOrange = new Color(255 / 255f, 187 / 255f, 92 / 255f);
                scoreColor.color = scoreOrange;
                break;
        }
    }

    public void UnlockEvent() {
        int numberGen = Random.Range(1, 5);
        switch (numberGen) {
            case 1:
                unlockKeyCode = KeyCode.W;
                break;
            case 2:
                unlockKeyCode = KeyCode.A;
                break;
            case 3:
                unlockKeyCode = KeyCode.S;
                break;
            case 4:
                unlockKeyCode = KeyCode.D;
                break;
        }

        isLock = true;
        isUnlockText = true;
    }

    public void DefaultSettings() {
        Color baseBackgroundColor = new Color(122 / 255f, 162 / 255f, 227 / 255f);
        Camera.main.backgroundColor = baseBackgroundColor;

        Color basePlayerColor = new Color(46 / 255f, 82 / 255f, 141 / 255f);
        playerColor.color = basePlayerColor;

        Color baseScoreColor = new Color(255 / 255f, 231 / 255f, 134 / 255f);
        scoreColor.color = baseScoreColor;

        playerMovement.rotationSpeed = baseSpeed;

        unlockKeyCode =KeyCode.None;
        isLock = false;
        isUnlockText = false;
        gameManager.unlockKeyCodeEventPanel.SetActive(false);

        isRandomSpeedEvent = false;
        isRandomColorEvent = false;
        isUnlockEvent = false;
    }

}
