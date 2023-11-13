using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using System.Linq;
using Sirenix.OdinInspector;
using System.Runtime.InteropServices;

public class StarPlot2 : SerializedMonoBehaviour
{
    [SerializeField][Range(0, 4)] int _starPlotIndex = 0;
    [SerializeField][Range(0.0f, 0.9f)] float _blackPercentage;

    [SerializeField] List<Line[]> _lines;
    [SerializeField] Polyline _surroundingLine;

    // Column 0: T
    // 1: TM
    // 2: H
    // 3: VV
    // 4: V
    // 5: VM
    // Column ist ein Datensatz mit 6 verschiedenen Parametern desselben Jahres
    // Row ist ein Parameter in den 5 Jahren

    float[,] _data = new float[,] {
        { 6500f, 4300f, 1200f, 900f, 6500f },
        { 89f, 71f, 59f, 48f, 94f },
        { 110, 76, 28, 43, 110 },
        { 4, 3, 2, 2, 4 },
        { 9, 9, 5, 3, 7 },
        { 4, 1, 4, 2, 1 },
        { 6, 3, 2, 6, 3 },
        { 7, 2, 7, 3, 5 },
    };

    float[,] _dataNormalized = new float[8, 5];

    private void Awake()
    {
        NormalizeData();
    }

    private void Start()
    {
        SetLines();
    }

    private void OnValidate()
    {
        SetLines();
    }

    void SetLines()
    {
        Vector3[] polyLinePoints = new Vector3[8];
        Color[] colorPoints = new Color[8];

        // Rays
        for (int i = 0; i < _lines.Count; i++)
        {
            if (i >= _data.GetLength(0))
            {
                Debug.LogWarning("Auf fehlende Daten zugegriffen.");
                return;
            }

            Line innerLine = _lines[i][0];
            Line outerLine = _lines[i][1];

            Vector3 direction = Vector2.right.Rotate(i * 45f);

            innerLine.Start = Vector3.zero;
            innerLine.End = direction.normalized * _blackPercentage;

            Vector3 lineEnd = innerLine.End + direction * _dataNormalized[i, _starPlotIndex] * (1-_blackPercentage);

            outerLine.Start = innerLine.End;
            outerLine.End = lineEnd;

            polyLinePoints[i] = outerLine.End;
            colorPoints[i] = outerLine.Color;
        }

        _surroundingLine.SetPoints(polyLinePoints);
        for (int i = 0; i <  polyLinePoints.Length; i++)
        {
            _surroundingLine.SetPointColor(i, colorPoints[i]);
        }
        
    }

    void NormalizeData()
    {
        for (int i = 0; i < _data.GetLength(0); i++)
        {
            float highestValue = float.NegativeInfinity;

            // Get highestValue
            for (int j = 0; j < _data.GetLength(1); j++)
            {
                if (highestValue < _data[i, j])
                {
                    highestValue = _data[i, j];
                }
            }

            for (int j = 0; j < _data.GetLength(1); j++)
            {
                _dataNormalized[i, j] = _data[i, j] / highestValue;
            }
        }
    }
}
