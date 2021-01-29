using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicTacToeHandler : MonoBehaviour
{
    List<TicTacToeField> fields = new List<TicTacToeField>();

    void Update()
    {
        CheckForWinner();
        

    }

    private void CheckForWinner()
    {
        
    }

    private void DrawShapeOnBoard()
    {
        // for (int x = 0; x <= 2; x++) 
        // {
        //     for (int y = 0; y <= 2; y++)
        //     {
        //         if (squares[x,y] == 0)
        //         {

        //         }
        //         else if (squares[x,y] == 1)
        //         {

        //         }
        //         else if (squares[x,y] == 2)
        //         {

        //         }
        //     }

        // }
    }
}
