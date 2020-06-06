using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject prefabX;
    public GameObject prefabZ;
    public Transform spawnx;
    public Transform spawnz;
    public static Transform _previous;

    private Transform _temp;
    private GameObject _current;
   
    public static bool isAxisX = true;
    private float y;
    private bool first = true;

    public event onSPresed onSPressed;
    public delegate void onSPresed();
    void Start()
    {
        StartCoroutine(spawnPrefs());
        y = spawnx.position.y;
        GameManager event2 = GetComponent<GameManager>();
        event2.onSPressed += spwn;
        _previous = GameObject.Find("Base").transform;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            //delegate event call
            onSPressed?.Invoke();
        }
    }

    public void spwn() {
        if (isAxisX) {
            Vector3 coord = new Vector3(spawnx.position.x, y, 0);
            
            _current =  Instantiate(prefabX, coord, Quaternion.identity);
            
            //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
            isAxisX = false;

        }
        else {
            Vector3 coord = new Vector3(0, y, spawnz.position.z);
            _current = Instantiate(prefabZ, coord, Quaternion.identity);
            //_current.transform.position = Vector3.Lerp(_current.transform.position, new Vector3(0, y, -4), 0.1f);
            isAxisX = true;
        }
        
        y += 0.2f;
    }

    private IEnumerator spawnPrefs() {
        
        yield return new WaitForSeconds(1f);
        Vector3 coord = new Vector3(spawnx.position.x, y, 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        Instantiate(prefabX, coord, rot);
        //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
        isAxisX = false;
        y += 0.2f;

    }
    
}
