using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCam : MonoBehaviour
{
    // Start is called before the first frame update
    float y;
    void Start()
    {
        GameObject go = GameObject.Find("Manager");
        GameManager event2 = go.GetComponent<GameManager>();
        event2.onSPressed += moveUp;
        y = transform.position.y;
    }


    public void moveUp() {
        Vector3 upper = new Vector3(transform.position.x, y, transform.position.z);
        transform.position += Vector3.up * 0.2f;
        y += 0.2f;
    }
    // Update is called once per frame
    
}
