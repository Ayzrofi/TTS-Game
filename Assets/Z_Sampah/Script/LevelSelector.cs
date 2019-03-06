using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {
    public static LevelSelector instance;

    public List<string> LevelName = new List<string>();
    int currentLvl;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentLvl = LevelName.Count;
        //Debug.Log (SceneManager.GetActiveScene().name);
        //LevelName.Remove(SceneManager.GetActiveScene().name);
    }

    public void LoadNewLevel()
    {
        if(LevelName.Count > 0)
        {
            int rand = Random.Range(0, LevelName.Count);
            SceneManager.LoadScene(LevelName[rand]);
            Debug.Log(LevelName[rand]);
            LevelName.RemoveAt(rand);
        }
        else 
        if(LevelName.Count <= 0)
        {
            SceneManager.LoadScene("Credit");
        }

    }

    public void ReloadLevel()
    {
        for (int i = 0; i < currentLvl; i++)
        {
            LevelName.Add("Level_" + i);
            Debug.Log(currentLvl);
        }
    }
    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        //LoadNewLevel();
    //        ReloadLevel();
    //        //if (LevelName.Count > 0)
    //        //{
    //        //    int rand = Random.Range(0, LevelName.Count);
    //        //    //LevelName.Sort();
    //        //    //Debug.Log(rand);
    //        //    Debug.Log(LevelName[rand]);
    //        //    LevelName.RemoveAt(rand);
    //        //}
    //        //else
    //        //if (LevelName.Count <= 0)
    //        //{
    //        //    //LevelName.Add("Bangsat kau");
    //        //    Debug.Log("Asoo loe ");
    //        //}

    //    }
    //}
}
