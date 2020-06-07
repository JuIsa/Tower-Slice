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
       
        GameObject prev = event2.getPrevious();
        float xscale = prev.transform.localScale.x;
        float zscale = prev.transform.localScale.z;
        transform.localScale = new Vector3(xscale, 0.2f, zscale);
        transform.position = new Vector3(prev.transform.position.x, transform.position.y, transform.position.z);
    }

    public void OnZCalled() {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();

        GameObject prev = event2.getPrevious();

        speed = 0;
        MovingZ mov = GetComponent<MovingZ>();

        float newz = transform.position.z / 2;

        float zscale = 4 - Math.Abs(transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, newz);
        transform.localScale = new Vector3(transform.localScale.x, 0.2f, zscale);


        
        event2.onSPressed -= OnZCalled;
        mov.enabled = false;
    }

    void Update() {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
