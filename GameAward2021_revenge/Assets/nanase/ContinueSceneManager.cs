using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject ClearSelectUI;
    private Image image_select;
    [SerializeField] private GameObject ClearNextUI;
    private Image image_next;

    private int num;

    private GameObject gameManager;
    private SaveManager SaveManager;
    private FadeManager fadeManager;

    public AudioClip clip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        image_select = ClearSelectUI.GetComponent<Image>();
        image_next = ClearNextUI.GetComponent<Image>();

        gameManager = GameObject.FindWithTag("GameManager");
        SaveManager = gameManager.GetComponent<SaveManager>();
        fadeManager = gameManager.GetComponent<FadeManager>();

        fadeManager.OnFadeOut();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeManager.GetIsFade() == -1 && fadeManager.GetAlfa() < 0.0f)
        {
            image_select.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            image_next.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);

            if (Input.GetAxis("Horizontal") > 0)
                num = 1;
            if (Input.GetAxis("Horizontal") < 0)
                num = 0;

            if (num == 1)
                image_select.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            if (num == 0)
                image_next.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                audioSource.PlayOneShot(clip);
                fadeManager.OnFadeIn();
            }
        }
        if (fadeManager.GetIsFade() == 1 && fadeManager.GetAlfa() > 1.0f)
        {
            if (num == 1)
                SceneManager.LoadScene("Select");
            if (num == 0)
            {
                // Œ»Ý‚ÌScene–¼‚ðŽæ“¾‚·‚é
                Scene nowScene = SceneManager.GetActiveScene();
                if (nowScene.name == "ClearScene")
                {
                    if (SaveManager.Load("stage8") > 0)
                        SceneManager.LoadScene("stage9");
                    else if (SaveManager.Load("stage7") > 0)
                        SceneManager.LoadScene("stage8");
                    else if (SaveManager.Load("stage6") > 0)
                        SceneManager.LoadScene("stage7");
                    else if (SaveManager.Load("stage5") > 0)
                        SceneManager.LoadScene("stage6");
                    else if (SaveManager.Load("stage4") > 0)
                        SceneManager.LoadScene("stage5");
                    else if (SaveManager.Load("stage3") > 0)
                        SceneManager.LoadScene("stage4");
                    else if (SaveManager.Load("stage2") > 0)
                        SceneManager.LoadScene("stage3");
                    else if (SaveManager.Load("Stage1") > 0)
                        SceneManager.LoadScene("stage2");
                    else
                        SceneManager.LoadScene("Stage1");
                }
                else
                {
                    SceneManager.LoadScene(SaveManager.LoadSceneName());
                }
            }
        }
    }


}
