using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class MovingPref : MonoBehaviour
{
    bool x;
    private float speed = 2.1f;
    private void Start() {
        x = GameManager.isAxisX;
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += localPrint;
    }

    public void localPrint() {
        Debug.Log("The word is ");
        speed = 0;
        MovingPref mov = GetComponent<MovingPref>();
        if (transform.position.x == 0) {
            float xstep = 2 - Math.Abs(0 - GameManager._previous.position.x);
            transform.localScale = new Vector3(xstep, 0.2f, 2);
            transform.position = new Vector3(transform.position.x + (2 - xstep) / 2, transform.position.y, 0);
        }
        else if(transform.position.z == 0) {
            float diff = Math.Abs(0 - transform.position.x);
            
            float newx = diff / 2;
            Debug.Log(newx);
            float xscale = Math.Abs(2 - newx);
            transform.position = new Vector3(newx, transform.position.y, 0);
            transform.localScale = new Vector3(xscale, 0.2f, 2f);

            
        }
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed -= localPrint;
        mov.enabled = false;
    }

    void Update()
    {
        if(!x)
            transform.position += Vector3.left* Time.deltaTime*speed;
        else
            transform.position += Vector3.back * Time.deltaTime*speed;
    }
}
