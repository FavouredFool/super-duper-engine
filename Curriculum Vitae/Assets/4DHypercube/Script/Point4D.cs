using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point4D : MonoBehaviour
{
    [SerializeField] Vector4 _coordinates;
    [SerializeField] TMP_Text _coordinateText;


    private void Start()
    {
        UpdateText();
    }
    private void OnValidate()
    {
        UpdateText();
    }

    void UpdateText()
    {
        string s = _coordinates[0] + " " + _coordinates[1] + " " + _coordinates[2] + " " + _coordinates[3];
        _coordinateText.text = s;
    }
}
