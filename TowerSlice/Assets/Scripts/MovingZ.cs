using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class MovingZ : MonoBehaviour {
    
    private float speed = 2.1f;
    private void Start() {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += OnZCalled;
    }

    public void OnZCalled() {
        speed = 0;
        MovingZ mov = GetComponent<MovingZ>();

        float newz = transform.position.z / 2;

        float zscale = 4 - Math.Abs(transform.position.z);
        transform.position = new Vector3(0, transform.position.y, newz);
        transform.localScale = new Vector3(4f, 0.2f, zscale);


        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed -= OnZCalled;
        mov.enabled = false;
    }

    void Update() {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
