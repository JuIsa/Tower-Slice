using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class MovingX : MonoBehaviour
{
    private float speed = 2.1f;
    private GameObject prev;
    private void Start() {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += OnXCalled;
        prev = event2.getPrevious();
        float xscale = prev.transform.localScale.x;
        float zscale = prev.transform.localScale.z;
        transform.localScale = new Vector3(xscale, 0.2f, zscale);
        transform.position = new Vector3(transform.position.x, transform.position.y, prev.transform.position.z);
        
       
    }

    public void OnXCalled() {
        speed = 0;
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        MovingX mov = GetComponent<MovingX>();
        
        //float newx = transform.position.x / 2;
        float newx = transform.position.x / (prev.transform.position.x + prev.transform.localScale.x/2);
        
        
        float xscale = (4 - Math.Abs(transform.position.x));

        transform.position = new Vector3(newx, transform.position.y, transform.position.z);
        transform.localScale = new Vector3(xscale, 0.2f, transform.localScale.z);

        event2.onSPressed -= OnXCalled;
        mov.enabled = false;
    }

    void Update()
    {
        transform.position += Vector3.left* Time.deltaTime*speed;
        
    }
}
