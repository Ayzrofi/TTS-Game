using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AnimalClassHolder
{
    public GameObject AnimalButton;
    //public Image Shiluet, color;
    public AudioClip animalSound;
    public bool IsInteractable;
    
}


public class AnimalCollectionsManajer : MonoBehaviour {
    public AudioSource AudioSrc;
    public GameObject effect;
    public List<AnimalClassHolder> Animals;

    private void Awake()
    {
        //PlayerPrefs.SetInt("Level_0", 1);
        //PlayerPrefs.SetInt("Level_2", 1);
        //PlayerPrefs.DeleteAll();

        //efek();

        for (int i = 0; i < Animals.Count; i++)
        {
            Animals[i].AnimalButton.GetComponent<Button>().interactable = false;
        }
    }
    private void Start()
    {
        StartCoroutine(efek());

    }

    IEnumerator efek()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Animals.Count; i++)
        {
            if (PlayerPrefs.GetInt("Level_" + i) == 1)
            {
                Animals[i].AnimalButton.GetComponent<Animator>().SetTrigger("Active");
                Animals[i].IsInteractable = true;
                yield return new WaitForSeconds(1f);
                Instantiate(effect, Animals[i].AnimalButton.transform);
                //Animals[i].AnimalButton.GetComponent<Button>().interactable = Animals[i].IsInteractable;
                //Animals[i].AnimalButton.GetComponent<Button>().onClick.AddListener(() => PlaySound(Animals[i].animalSound)); 
                LoadAllInformations();
                
                
            }
        }
    }
    
    public void LoadAllInformations()
    {
        foreach (var item in Animals)
        {

            item.AnimalButton.GetComponent<Button>().interactable = item.IsInteractable;
            item.AnimalButton.GetComponent<Button>().onClick.AddListener(() => PlaySound(item.animalSound));
        }
    }

    public void PlaySound(AudioClip Audio)
    {
        if (AudioSrc.isPlaying)
            AudioSrc.Stop();

        AudioSrc.PlayOneShot(Audio);
    }

}
