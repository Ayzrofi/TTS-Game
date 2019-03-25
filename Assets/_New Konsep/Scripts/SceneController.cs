using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneController : MonoBehaviour {

    private static SceneController instance;
    public static SceneController TheInstanceOfSceneController
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneController>();
            }
            return instance;
        }
    }

    public AudioSource As;
    public AudioClip ButtonSfx;

    public Animator PanelAnim;

    private void Awake()
    {
        if (As == null)
            As = GetComponent<AudioSource>();

    }

    public void LoadScene(string SceneName)
    {
        PanelAnim.SetTrigger("Close");
        PlaySfx(ButtonSfx);
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        PanelAnim.SetTrigger("Close");
        PlaySfx(ButtonSfx);
        Application.Quit();
    }

    public void PlaySfx(AudioClip clip)
    {
        if (As.isPlaying)
            As.Stop();

        As.PlayOneShot(clip);
    }


    public IEnumerator PlayTransisiAnimasi()
    {
        PanelAnim.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(1f);
        PanelAnim.SetTrigger("Open");
    }


}
