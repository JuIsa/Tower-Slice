using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class MovingX : MonoBehaviour
{
    private float speed = 2.1f;
    private void Start() {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += OnXCalled;
    }

    public void OnXCalled() {
        
        speed = 0;
        MovingX mov = GetComponent<MovingX>();
            
        float newx = transform.position.x / 2;
        
        float xscale = 4 - Math.Abs(transform.position.x);
        transform.position = new Vector3(newx, transform.position.y, 0);
        transform.localScale = new Vector3(xscale, 0.2f, 4f);

            
        
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed -= OnXCalled;
        mov.enabled = false;
    }

    void Update()
    {
        transform.position += Vector3.left* Time.deltaTime*speed;
        
    }
}
