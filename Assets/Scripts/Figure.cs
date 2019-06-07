using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour, IFigure
{
    private int _score;

    public void GetHit()
    {
        // somecode
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
