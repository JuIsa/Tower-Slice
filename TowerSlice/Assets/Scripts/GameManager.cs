using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject prefab;
    public Transform spawnx;
    public Transform spawnz;
    private GameObject _current;
    private GameObject _previous;
    public static bool isAxisX = true;
    private float y;

    public event onSPresed onSPressed;
    public delegate void onSPresed();
    void Start()
    {
        StartCoroutine(spawnPrefs());
        y = spawnx.position.y;
        GameManager event2 = GetComponent<GameManager>();
        event2.onSPressed += spwn;
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
            Quaternion rot = Quaternion.Euler(0, -90f, 0);
            Instantiate(prefab, coord, rot);
            //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
            isAxisX = false;

        }
        else {
            Vector3 coord = new Vector3(0, y, spawnz.position.z);
            Quaternion rot = Quaternion.Euler(0, 180f, 0);
            Instantiate(prefab, coord, Quaternion.identity);
            //_current.transform.position = Vector3.Lerp(_current.transform.position, new Vector3(0, y, -4), 0.1f);
            isAxisX = true;
        }
        // cubes.Add(_current);
        y += 0.2f;
    }

    private IEnumerator spawnPrefs() {
        
        yield return new WaitForSeconds(2f);
        Vector3 coord = new Vector3(spawnx.position.x, y, 0);
        Quaternion rot = Quaternion.Euler(0, -90f, 0);
        Instantiate(prefab, coord, rot);
        //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
        isAxisX = false;
        y += 0.2f;

    }
    
}
