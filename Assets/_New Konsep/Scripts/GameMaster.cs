using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameMaster : MonoBehaviour {

    public AudioSource AudioSrc;
    public AudioClip ButtonsSfx;
    [Space(30)]
    public GameObject FieldJawabanPrefabs;
    public Transform FieldJawabanTargetParent;
    public Button ButtonSoal;
    public Button[] AllButtonJawaban;
    [Space(25)]
    public List<Question> Soal;

    private List<string> listHurufSoal = new List<string>();
    List<string> jawabanBenar = new List<string>();
    private string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    int SoalYangDiTampilkan;
    Text[] m_Huruf;
    string Kata;
    int F = 0;
    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();
    }

    private void Start()
    {
        CreateLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            CreateLevel();

        if (Input.GetKeyDown(KeyCode.S))
            DeleteFieldJawaban();

        if (Input.GetKeyDown(KeyCode.D))
            ClearFieldJawban();
    }

    public void CreateLevel()
    {
        if(Soal.Count > 0)
        {
            F = 0;

            SoalYangDiTampilkan = Random.Range(0, Soal.Count);

            ButtonSoal.onClick.RemoveAllListeners();
            ButtonSoal.onClick.AddListener(() => PlaySound(Soal[SoalYangDiTampilkan].SfxSoal));
            ButtonSoal.gameObject.GetComponent<Image>().sprite = Soal[SoalYangDiTampilkan].ImageSoal;
            ButtonSoal.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);

            //DeleteFieldJawaban();
            CreateFieldJawaban();
            CreateButtonsJawaban();
           
        }
        Debug.Log(FieldJawabanTargetParent.transform.childCount);
    }
    public void ClearFieldJawban()
    {
        Kata = "";
        F = 0;
        for (int i = 0; i < m_Huruf.Length; i++)
        {
            m_Huruf[i].text = "";
        }
    }
    public void DeleteFieldJawaban()
    {
        // Hapus Field Sebelumnya
        //GameObject[] CurrentHurufField = GameObject.FindGameObjectsWithTag("Huruf");
        //if (CurrentHurufField != null)
        //{
        //    foreach (var item in CurrentHurufField)
        //    {
        //        Destroy(item.gameObject);
        //        Debug.Log("Object Destroyed");
        //    }
        //}

        for (int i = 0; i < FieldJawabanTargetParent.transform.childCount; i++)
        {
            //FieldJawabanTargetParent.transform.GetChild(i).gameObject.SetActive(false);
            Destroy(FieldJawabanTargetParent.transform.GetChild(i).gameObject);
            Debug.Log("Nyaa");
        }
        Debug.Log(FieldJawabanTargetParent.transform.childCount);

        Kata = "";
        F = 0;
        for (int i = 0; i < m_Huruf.Length; i++)
        {
            m_Huruf[i].text = "";
        }
    }

    public void CreateFieldJawaban()
    {
       
        /// Bikin Field Huruf baru
        for (int i = 0; i < Soal[SoalYangDiTampilkan].TextSoal.Length ; i++)
        {
            //Debug.Log(Soal[SoalYangDiTampilkan].TextSoal.Length);
            GameObject go = Instantiate(FieldJawabanPrefabs, FieldJawabanTargetParent.transform, false) as GameObject;
        }
        /// Set field huruf Baru
        /// 
        GameObject[] HurufField = GameObject.FindGameObjectsWithTag("Huruf");
        //Debug.Log(HurufField.Length);

        m_Huruf = new Text[HurufField.Length];

        for (int i = 0; i < HurufField.Length; i++)
        {
            m_Huruf[i] = HurufField[i].GetComponentInChildren<Text>();
            m_Huruf[i].text = "";
            //HurufField[HurufField.Length - 1].SetActive(false);
        }


    }

    public void CreateButtonsJawaban()
    {
        //Debug.Log(Soal[SoalYangDiTampilkan].TextSoal);

        listHurufSoal.Clear();
        jawabanBenar.Clear();
        int ValueJawabanBenar = -1;

        foreach (var item in Soal[SoalYangDiTampilkan].TextSoal)
        {
            listHurufSoal.Add(item.ToString());
        }

        /////
        for (int i = 0; i < AllButtonJawaban.Length; i++)
        {
            AllButtonJawaban[i].onClick.RemoveAllListeners();
            AllButtonJawaban[i].onClick.AddListener(() => PlaySound(ButtonsSfx));
            bool HurufYangBenar = (Random.value > 0.5f);

            if(listHurufSoal.Count > 0)
            {
                if (HurufYangBenar)
                {
                    int RandomHurufSoal = Random.Range(0, listHurufSoal.Count);
                    AllButtonJawaban[i].transform.GetChild(0).GetComponent<Text>().text = listHurufSoal[RandomHurufSoal];

                    jawabanBenar.Add(listHurufSoal[RandomHurufSoal]);

                    ValueJawabanBenar++;
                    int Value = ValueJawabanBenar;
                    AllButtonJawaban[i].onClick.AddListener(() => AddCharakter(jawabanBenar[Value]));
                    
                    //Debug.Log(jawabanBenar[Value]);
                    //Debug.Log(Value);
                    listHurufSoal.RemoveAt(RandomHurufSoal);
                }
                else
                {
                    int RandomHuruf = Random.Range(0, Alphabets.Length);
                    AllButtonJawaban[i].transform.GetChild(0).GetComponent<Text>().text = Alphabets[RandomHuruf].ToString();
     
                    AllButtonJawaban[i].onClick.AddListener(() => AddCharakter(Alphabets[RandomHuruf].ToString()));
                }
            }
            else
            {
                int RandomHuruf = Random.Range(0, Alphabets.Length);
                AllButtonJawaban[i].transform.GetChild(0).GetComponent<Text>().text = Alphabets[RandomHuruf].ToString();
                AllButtonJawaban[i].onClick.AddListener(() => AddCharakter(Alphabets[RandomHuruf].ToString()));
            }
        }

        if(listHurufSoal.Count > 0)
        {
            Debug.Log("Ada Huruf Yg Tersisa");
            CreateButtonsJawaban();
        }
    }

   

    public void AddCharakter(string Charakter)
    {

        if(F < m_Huruf.Length)
        {
            Kata += Charakter;
            Debug.Log(Kata);

            m_Huruf[F].text = Kata[F].ToString();

            F++;

            if (F >= m_Huruf.Length)
            {
                if (Kata == Soal[SoalYangDiTampilkan].TextSoal)
                    WinGame();
                else
                    LoseGame();
            }
        }
       
        // untuk riset huruf di layar supaya kembali bersih tanpa noda 

        //if (F >= m_Huruf.Length)
        //{
        //    if (Kata == Soal[SoalYangDiTampilkan].TextSoal)
        //        WinGame();
        //    else
        //        LoseGame();

        //    Kata = "";
        //    F = 0;
        //    for (int i = 0; i < m_Huruf.Length; i++)
        //    {
        //        m_Huruf[i].text = "";
        //    }
        //}
    }

    public void WinGame()
    {
        Debug.Log("You Win");
        ButtonSoal.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void LoseGame()
    {
        Debug.Log("You Lose");
    }

    public void PlaySound(AudioClip Clip)
    {
        if (AudioSrc.isPlaying)
            AudioSrc.Stop();

        AudioSrc.PlayOneShot(Clip);
    }
}
