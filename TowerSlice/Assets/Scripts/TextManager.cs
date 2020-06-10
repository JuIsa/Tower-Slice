
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Text _text;
    private int score = 0;
    void Start()
    {
        GameObject go = GameObject.Find("Manager");
        GameManager eventS = go.GetComponent<GameManager>();
        eventS.onSPressed += UpdateScore;
        eventS.onRestarted += ResetScore;
        _text = GetComponent<Text>();
    }

    public void UpdateScore() {
        _text.enabled = true;
        score++;
        _text.text = score.ToString();
    }
    public void ResetScore() {
        score = 0;
        _text.text = score.ToString(); 
    }
}
