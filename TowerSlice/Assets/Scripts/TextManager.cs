using System.Collections;
using System.Collections.Generic;
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

        _text = GetComponent<Text>();
    }

    public void UpdateScore() {
        _text.enabled = true;
        score++;
        _text.text = score.ToString();
    }
}
