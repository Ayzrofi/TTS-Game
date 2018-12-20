// if its work leave it Dont touch Again 
// Go to sleep or watching anime 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    [Header("Pakai Huruf Kapitalis / Besar Semua")]
    public string KataKunci;
    [Header("Huruf Image Prefabs")]
    public GameObject HurufImage;
    [Header ("Parent Dari Image Yg Akan Di Instance")]
    public Transform HurufImageParent;
    [Header("Gambar Binatang")]
    public GameObject imageSilhuoete;
    public GameObject imageColor;
    [Header("Particle Effect")]
    public GameObject WinEffect;
    [Header("Pop Up Menu Animator")]
    public Animator Anime;
    // variabel untuk menyimpan huruf dalam array 
    Text[] m_Huruf;
    // ini variabel string yg akan di otak atik sedikit demi sedikit 
    string Kata;
    // Dont touch this variabel its dangerous
    int F = 0;

    private void Awake()
    {
        // membuat game object huruf image sesuai dgn jumlah kata kunci
        for (int i = 0; i < KataKunci.Length +1 ; i++)
        {
            //Huruf = new Text[i + 1];
            GameObject Go = Instantiate(HurufImage, HurufImageParent.transform, false) as GameObject;
            Go.name = "Huruf";
        }
        imageColor.SetActive(false);
    }
    private void Start()
    {
        // mencari semua game object dengan tag tertentu
        GameObject[] asuu = GameObject.FindGameObjectsWithTag("Huruf");
   
        // menginisialisasi ulang jumlah array san i omakase nanoda 
        // supaya array tidak out of range guys
        m_Huruf = new Text[asuu.Length ];
        // getting refrence to text component in child from game object and set him to null
        for (int i = 0; i < asuu.Length ; i++)
        {
            m_Huruf[i] = asuu[i].GetComponentInChildren<Text>();
            m_Huruf[i].text = " ";
            // supaya kita bisa liat full 'kata' nya baru te riset ke null lagi
            asuu[asuu.Length - 1].SetActive(false);        
            // ntah lah ini kenapa gw komment
            //Text newtext = asuu[i].GetComponentInChildren<Text>();
            //m_Huruf[i] = newtext;
            //Debug.Log(newtext.text);
        }
        // sama ini juga gw dah lupa kenapa ini gw komment

        //foreach (GameObject Huruf in asuu)
        //{
        //    Text newText = Huruf.GetComponentInChildren<Text>();
        //    Debug.Log(newText.text); 
        //}
    }
   
    // just leave this function like this

    //private void Start()
    //{
    //    //for (int i = 0; i < Kata.Length; i++)
    //    //{
    //    //    //Huruf = new Text[i + 1];
    //    //    GameObject Go = Instantiate(HurufImage, this.transform, false);
    //    //    Go.name = "Huruf";
    //    //}

    //    for (int i = 0; i < m_Huruf.Length; i++)
    //    {
    //        //Kata[i].ToString();
    //        m_Huruf[i].text = " ";
    //        //Debug.Log("Huruf ke " + i + " " + Kata[i]);
    //    }
    //}
    // function untuk menambah length dari kata dengan metode press button
    public void AddCharakter(string Charakter)
    {
        Kata += Charakter;
        //Debug.Log(Kata);
        
        m_Huruf[F].text = Kata[F].ToString();
        if (Kata == KataKunci)
            WinGame();

        F++;
        // untuk riset huruf di layar supaya kembali bersih tanpa noda 
        if (F  >= m_Huruf.Length )
        {
            if (Kata == KataKunci)
                WinGame();
            else
                LoseGame();

            Kata = "";
            F = 0;
            for (int i = 0; i < m_Huruf.Length; i++)
            {
                m_Huruf[i].text = "";
            }
        }

    }
    // Kondisi Ketika Anda Kalah Main Suatu Game 
    private void LoseGame()
    {
        Debug.Log("Dasar Noob Loe");
        Anime.SetTrigger("Lose");
    }

    // yay akhirnya menang UwU
    private void WinGame()
    {
        Debug.Log("asuu Lo");
        Instantiate(WinEffect, imageColor.transform);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        Debug.Log(SceneManager.GetActiveScene().name);
        Anime.SetTrigger("Win");
        imageSilhuoete.SetActive(false);
        imageColor.SetActive(true);
    }
}
