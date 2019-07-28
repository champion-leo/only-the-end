﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float laserTime;
    void Start () {

    }
    void Awake () {
        laserTime = 1f;
    }

    // Update is called once per frame
    void Update () {
        laserTime -= Time.deltaTime;
        if (laserTime < 0) {
            Destroy(gameObject);
        }
    }

    public void Launch (float angle) {
        // Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        onTrigger(other);
    }
    private void OnTriggerStay2D(Collider2D other) {
        onTrigger(other);
    }

    private void onTrigger(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            HeroController e = other.GetComponent<HeroController> ();
            if (laserTime < 0.2f) {
                e.Dommage(2);
            }
        }
    }
}