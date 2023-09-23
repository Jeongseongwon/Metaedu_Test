using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLauncher_ICT : MonoBehaviour
{
    public GameObject Loading;
    public GameObject Mode;
    public GameObject Lobby_teacher;
    public GameObject Lobby_student;
    public GameObject Setting;

    // Start is called before the first frame update
    [SerializeField]
    public Slider progressBar;
    public Text loadingPercent;
    public Image loadingIcon;

    private bool loadingCompleted;
    private int nextScene;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadScene());
        StartCoroutine(RotateIcon());

        loadingCompleted = false;
        nextScene = 0;
    }

    IEnumerator LoadScene()
    {
        //yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        //while (!op.isDone)
        while (true)
        {
            //yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1f, timer);
                loadingPercent.text = "progressBar.value";

                if (progressBar.value == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, op.progress, timer);
                if (progressBar.value >= op.progress)
                {
                    timer = 0f;

                    //End of scene index
                    if (nextScene == 2 && loadingCompleted)
                    {
                        StopAllCoroutines();
                    }
                }
            }
        }
    }

    IEnumerator RotateIcon()
    {
        float timer = 0f;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            timer += Time.deltaTime;

            Debug.Log(progressBar.value);
            //Debug.Log("check");
            if (progressBar.value < 100f)
            {
                progressBar.value = Mathf.RoundToInt(Mathf.Lerp(progressBar.value, 100f, timer / 8));
                loadingIcon.rectTransform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
                loadingPercent.text = progressBar.value.ToString();
            }
            else
            {
                StopAllCoroutines();
                //Debug.Log("100%");

                Loading.SetActive(false);
                Mode.SetActive(true);
            }
        }
    }

    public void Button_Gamestart()
    {
        //Main.SetActive(false);
        //Menu.SetActive(true);
    }
    public void Button_Modes(string contentname)
    {
        Mode.SetActive(false);
        if (contentname == "TEACHER")
        {
            Lobby_teacher.SetActive(true);
        }
        else if(contentname == "STUDENT")
        {
            Lobby_student.SetActive(true);
        }
    }
    public void Button_Contents(int contentname)
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Button_Back_ToMode()
    {
        Lobby_teacher.SetActive(false);
        Lobby_student.SetActive(false);
        Mode.SetActive(true);
    }

    public void Button_Setting()
    {
        Setting.SetActive(true);
    }
}
