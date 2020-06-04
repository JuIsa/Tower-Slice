using System.Collections;
using System.Collections.Generic;
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
