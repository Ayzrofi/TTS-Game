using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomAlphabet : MonoBehaviour {


    string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [Header("Jumlah Kata Harus Kurang Dari 2/3 dari Jumlah Buttons")]
    public string Jawaban;
    public List<string> Jwb = new List<string>();
    public Text[] ButtonsText;

    bool AcakSelesai = false;

    private void Start()
    {
        JawabanButtons();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            JawabanButtons();
        }
    }

    public void JawabanButtons()
    {
        Jwb.Clear();
        foreach (var item in Jawaban)
        {
            Jwb.Add(item.ToString());
        }

        foreach (Text item in ButtonsText)
        {
            bool HurufYangBenar = (Random.value > 0.5f);

            if(Jwb.Count > 0)
            {
                if (HurufYangBenar)
                {

                    int jRand = Random.Range(0, Jwb.Count);
                    item.text = Jwb[jRand].ToString();
                    Jwb.RemoveAt(jRand);

                    //if (Jwb.Count <= 0)
                    //{
                    //    AcakSelesai = true;
                    //}
                }
                else
                {
                    int Rand = Random.Range(0, Alphabets.Length);
                    item.text = Alphabets[Rand].ToString();
                }
            }
            else
            {
                int Rand = Random.Range(0, Alphabets.Length);
                item.text = Alphabets[Rand].ToString();
            }
           
        }

        if(Jwb.Count > 0)
        {
            Debug.Log("Masih Ada Sisa ASUU");
            JawabanButtons();
        }
    }

    //[ContextMenu("Create Alphabets")]
    //public void CreateAlphabet()
    //{
    //    //AcakSelesai = false;
    //    foreach (var item in Jawaban)
    //    {
    //        Jwb.Add(item.ToString());
    //    }

    //    while (Jwb.Count > 0 && !AcakSelesai)
    //    {
    //        for (int i = 0; i < ButtonsText.Length; i++)
    //        {
    //            bool HurufYangBenar = (Random.value > 0.5f);

    //            if (HurufYangBenar)
    //            {
    //                int jRand = Random.Range(0, Jwb.Count);
    //                ButtonsText[i].text = Jwb[jRand].ToString();
    //                Debug.Log(i + "-" + Jwb[jRand]);
    //                Jwb.RemoveAt(jRand);

    //                if (Jwb.Count <= 0)
    //                {
    //                    AcakSelesai = true;
    //                }
    //            }
    //            else
    //            {
    //                int Rand = Random.Range(0, Alphabets.Length);
    //                ButtonsText[i].text = Alphabets[Rand].ToString();
    //                Debug.Log(i);
    //            }
    //        }
    //    }



    //}
}
