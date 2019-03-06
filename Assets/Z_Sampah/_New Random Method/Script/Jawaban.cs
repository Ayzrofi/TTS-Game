using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jawaban : MonoBehaviour {

    public static Jawaban instance;

    public List<GameObject> Questions = new List<GameObject>();
    public Transform QuestionHolder;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start () {
        createQuestion();
        //for (int i = 0; i < Questions.Count; i++)
        //{
        //    GameObject go = Instantiate(Questions[i], QuestionHolder.transform, false);
        //    go.SetActive(false);
        //}
    }
	
	public void createQuestion()
    {
        if(Questions.Count > 0)
        {
            int rand = Random.Range(0, Questions.Count);
            GameObject go = Instantiate(Questions[rand], QuestionHolder.transform, false);
            Questions.RemoveAt(rand);
        }
        else
        {
            Debug.Log("You WIn");
        }
       
    }

}
