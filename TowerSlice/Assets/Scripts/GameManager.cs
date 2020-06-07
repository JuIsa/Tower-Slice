using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GameManager : MonoBehaviour
{

    public GameObject prefabX;
    public GameObject prefabZ;
    public Transform spawnx;
    public Transform spawnz;
    public static Transform _previous;
    public GameObject background;
    public Color _color;
    
    private Transform _temp;
    private GameObject _current;
   
    public static bool isAxisX = true;
    private float y;
    private bool first = true;
    private float colorSpeed = 0.1f;

    private Gradient _gradientC;

    private MeshRenderer mr;

    public event onSPresed onSPressed;
    public delegate void onSPresed();
    void Start()
    {
        StartCoroutine(spawnPrefs());
        y = spawnx.position.y;
        GameManager event2 = GetComponent<GameManager>();
        event2.onSPressed += spwn;
        GenerateGradualColors();
        _previous = GameObject.Find("Base").transform;
        mr = background.GetComponent<MeshRenderer>();
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
            MeshRenderer m = _current.GetComponent<MeshRenderer>();
            
            m.material.color = _gradientC.Evaluate(y * colorSpeed);
            _color = _gradientC.Evaluate(y * colorSpeed);
            Debug.Log(_color);
            //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
            isAxisX = false;
           // mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);
           

        }
        else {
            Vector3 coord = new Vector3(0, y, spawnz.position.z);
            _current = Instantiate(prefabZ, coord, Quaternion.identity);
            MeshRenderer m = _current.GetComponent<MeshRenderer>();
           
            m.material.color = _gradientC.Evaluate(y * colorSpeed);
            _color = _gradientC.Evaluate(y * colorSpeed);
            Debug.Log(_color);
            //_current.transform.position = Vector3.Lerp(_current.transform.position, new Vector3(0, y, -4), 0.1f);
            isAxisX = true;
            //mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);
        }
        
        y += 0.2f;
    }

    private IEnumerator spawnPrefs() {
        
        yield return new WaitForSeconds(1f);
        Vector3 coord = new Vector3(spawnx.position.x, y, 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        _current = Instantiate(prefabX, coord, rot);
        MeshRenderer m = _current.GetComponent<MeshRenderer>();

        m.material.color = _gradientC.Evaluate(y * colorSpeed);
        _color = _gradientC.Evaluate(y * colorSpeed);
        //mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);
        //               
        isAxisX = false;
        y += 0.2f;

    }
    
    private void GenerateGradualColors() {
        _gradientC = new Gradient();
        int size = 2;
        GradientColorKey[] colors = new GradientColorKey[size];
        GradientAlphaKey[] alphas = new GradientAlphaKey[size];
        float x255 = 255f;
        float startr = 67f / x255;
        float startg = 230f / x255;
        float startb = 115f / x255;
        Color start = new Color(startr, startg, startb, 1f);

        float endr = 67f / x255;
        float endg = 219f / x255;
        float endb = 230f / x255;
        Color end = new Color(endr, endg, endb, 1f);
        //find difference in colors
        float diffg = start.g - end.g;
        float diffb = start.b - end.b;
        //how fast change
        float overtimeG = diffg / size;
        float overtimeB = diffb / size;

        float g = start.g;
        float b = start.b;
        /*multiple colors
        for(int i = 0; i < size; i++) {
            g += overtimeG;
            b += overtimeG;
            Color temp = new Color(67, g, b);
            colors[i].color = temp;
            colors[i].time = i;
            alphas[i].alpha = 1;
            alphas[i].time = i;
            
        }
        */
        colors[0].color = start;
        colors[0].time = 0;
        colors[1].color = end;
        colors[1].time = 1;

        alphas[0].alpha = 1;
        alphas[0].time = 0;
        alphas[1].alpha = 1;
        alphas[1].time = 1;


        _gradientC.SetKeys(colors, alphas);


    }
}
