using TMPro;
using UnityEngine;

public class TextWithValue : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private TMP_Text _value;

    public void SetText(string text) => _winText.text = text;

    public void SetValue(string text) => _value.text = text;
}