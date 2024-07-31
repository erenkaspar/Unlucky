using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectScript : MonoBehaviour
{

    public bool perfectArea = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PerfScore")) {
            perfectArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("PerfScore")) {
            perfectArea = false;
        }
    }
}
