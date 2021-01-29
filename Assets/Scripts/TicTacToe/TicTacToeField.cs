using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TicTacToeField : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private int value;

    void Awake() => text = GetComponentInChildren<TMP_Text>();

    void LateUpdate() => SetText();

    public int GetX() => x;
    public int GetY() => y;
    public int GetValue() => value;

    private void SetText()
    {
        switch(value)
        {
            case 0: 
                text.text = " ";
                break;
            case 1: 
                text.text = "X";
                break;
            case 2: 
                text.text = "O";
                break;
        }
    }

     public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Pressed: {x}, {y}");
        ++value;
        if (value > 2) value = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

}
