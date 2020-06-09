using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class MovingZ : MonoBehaviour {
    
    private float speed = 2.1f;
    private GameObject prev;
    private void Start() {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += OnZCalled;
        prev = event2.getPrevious();
        float xscale = prev.transform.localScale.x;
        float zscale = prev.transform.localScale.z;
        transform.localScale = new Vector3(xscale, 0.2f, zscale);
        transform.position = new Vector3(prev.transform.position.x, transform.position.y, transform.position.z);
        

        
    }

    public void OnZCalled() {
        speed = 0;
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();

        MovingZ mov = GetComponent<MovingZ>();

        //float newz = transform.position.z / 2;
        //float newz = transform.position.z / (prev.transform.position.z + prev.transform.localScale.z / 2);
        float z = 0;
        float temp = 0;
        float newz = 0;
       
        float zscale = 0;
        if (transform.position.z > prev.transform.position.z) {
            z = prev.transform.position.z + (prev.transform.localScale.z / 2f);
            temp = transform.position.z - transform.localScale.z / 2;
            newz = (z + temp) / 2;

            zscale = Math.Abs((z - newz) * 2);
        }
        else {
            z = prev.transform.position.z - (prev.transform.localScale.z / 2f);
            temp = transform.position.z + transform.localScale.z / 2;
            newz = (z + temp) / 2;

            zscale = Math.Abs((-z + newz) * 2);
        }
        print(transform.position.z);
        print(z);
        print(temp);
        print(newz);
        print(zscale);
        //float zscale = 4 - Math.Abs(transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, newz);
        transform.localScale = new Vector3(transform.localScale.x, 0.2f, zscale);


        
        event2.onSPressed -= OnZCalled;
        mov.enabled = false;
    }

    void Update() {
        transform.position += Vector3.back * Time.deltaTime * speed;
    }
}
