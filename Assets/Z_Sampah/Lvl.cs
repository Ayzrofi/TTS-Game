using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour {
    public int currentLvl;
    public int LevelNumber;
    public lvlName[] LevelType;

   
    
    private void Start()
    {
        int currentLvl = LevelType[LevelNumber].SceneName.Count;
        Debug.Log(currentLvl);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            LoadnewLevel();

        if (Input.GetKeyDown(KeyCode.S))
            ReloadLevel();

        if (Input.GetKeyDown(KeyCode.D))
        {
            LevelNumber++;
            if (LevelNumber >= 3)
                LevelNumber = 0;
        }
    }

    [ContextMenu("Load new Lvl")]
    public void LoadnewLevel()
    {
        if (LevelType[LevelNumber].SceneName.Count > 0)
        {
            int rand = Random.Range(0, LevelType[LevelNumber].SceneName.Count);
            //SceneManager.LoadScene(LevelName[rand]);
            //Debug.Log(LevelName[rand]);
            Debug.Log(LevelType[LevelNumber].SceneName[rand]);
            LevelType[LevelNumber].SceneName.RemoveAt(rand);
            //LevelName.RemoveAt(rand);
        }
        else
        if (LevelType[LevelNumber].SceneName.Count <= 0)
        {
            //SceneManager.LoadScene("Credit");
            Debug.Log("Game Over");
        }
    }
    [ContextMenu("Reload Level")]
    public void ReloadLevel()
    {
        LevelType[LevelNumber].SceneName.Clear();
        for (int i = 0; i < currentLvl; i++)
        {
            //LevelName.Add("Level_" + i);
            LevelType[LevelNumber].SceneName.Add(LevelType[LevelNumber].LevelType +"_"+ i);
            Debug.Log(currentLvl);
        }
    }
}
