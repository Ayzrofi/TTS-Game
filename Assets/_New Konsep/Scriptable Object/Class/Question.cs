using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Question", menuName = "Create Question")]
public class Question : ScriptableObject {
    [Header("Soal")]
    public Sprite ImageSoal;
    [Header("Text Jawaban Soal (Huruf Kapital)")]
    public string TextSoal;
    [Header("Suara Dari Soal")]
    public AudioClip SfxSoal;

}
