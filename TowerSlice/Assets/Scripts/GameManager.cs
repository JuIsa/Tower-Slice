using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GameManager : MonoBehaviour
{
    [Header("Prefs")]
    public GameObject prefabX;
    public GameObject prefabZ;
    public Transform spawnx;
    public Transform spawnz;
    public GameObject _previous;
    public GameObject background;
    [Header("Colors")]
    public Color _color1;
    public Color _color2;
    public Color _color3;
    public Color _color4;
    public Color _color5;
    public Color _color6;
    public Color _color7;
    public Color[] _colors;
    private Transform _temp;
    private GameObject _current;
   
    public static bool isAxisX = true;
    private float y;
    private bool first = true;
    private float colorSpeed = 0.1f;
    private int counter = 0;

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
        GenerateGradualColorsFromPublic();
        _previous = GameObject.Find("Base");
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
        _previous = _current;
        if (isAxisX) {
            Vector3 coord = new Vector3(spawnx.position.x, y, 0);
            
            _current =  Instantiate(prefabX, coord, Quaternion.identity);
            MeshRenderer m = _current.GetComponent<MeshRenderer>();
     
            m.material.color = _gradientC.Evaluate(y * colorSpeed);
            _color1 = _gradientC.Evaluate(y * colorSpeed);
           // Debug.Log(_color1);
            //               _current.transform.position = Vector3.Lerp(coord, new Vector3(-4, y, 0), 0.2f);
            isAxisX = false;
           // mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);
           

        }
        else {
            Vector3 coord = new Vector3(0, y, spawnz.position.z);
            _current = Instantiate(prefabZ, coord, Quaternion.identity);
            MeshRenderer m = _current.GetComponent<MeshRenderer>();
           
            m.material.color = _gradientC.Evaluate(y * colorSpeed);
            _color1 = _gradientC.Evaluate(y * colorSpeed);
            //Debug.Log(_color1);
            //_current.transform.position = Vector3.Lerp(_current.transform.position, new Vector3(0, y, -4), 0.1f);
            isAxisX = true;
            //mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);
        }

        _current.name = "Cube" + counter;
        counter++;

        
        y += 0.2f;
    }

    private IEnumerator spawnPrefs() {
        
        yield return new WaitForSeconds(1f);
        Vector3 coord = new Vector3(spawnx.position.x, y, 0);
        Quaternion rot = Quaternion.Euler(0, 0, 0);
        _current = Instantiate(prefabX, coord, rot);
        MeshRenderer m = _current.GetComponent<MeshRenderer>();
        _current.name = "Cube"+counter;
        counter++;
        m.material.color = _gradientC.Evaluate(y * colorSpeed);
        _color1 = _gradientC.Evaluate(y * colorSpeed);
        //Color of background
        //mr.material.color = _gradientC.Evaluate(y * colorSpeed * 0.2f);               
        isAxisX = false;
        y += 0.2f;

        //change previous cube


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

    private void GenerateGradualColorsFromPublic() {
        _gradientC = new Gradient();
        int size = _colors.Length;
        GradientColorKey[] colors = new GradientColorKey[size];
        GradientAlphaKey[] alphas = new GradientAlphaKey[size];
        for(int i = 0; i < size; i++) {
            Debug.Log(_colors[i]);
            colors[i].color = _colors[i];
            colors[i].time = (float)i / (float)size;
            alphas[i].alpha = 1;
            alphas[i].time = (float)i / (float)size;
            if (i == size - 1) {
                colors[i].color = _colors[i];
                colors[i].time = 1;
                alphas[i].alpha = 1;
                alphas[i].time = 1;
            }
        }
        _gradientC.SetKeys(colors, alphas);
    }

    public GameObject getPrevious() {
        return _previous;
    }
}
