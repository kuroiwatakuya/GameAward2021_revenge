using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject TitlestartUI;
    private Image image_start;

    private float alpha;
    private float aspeed;

    private GameObject gameManager;
    private FadeManager fadeManager;

    public AudioClip clip;
    private AudioSource audioSource;

    void Start()
    {
        alpha = 1.0f;
        aspeed = -0.5f;
        image_start = TitlestartUI.GetComponent<Image>();

        gameManager = GameObject.FindWithTag("GameManager");
        fadeManager = gameManager.GetComponent<FadeManager>();

        fadeManager.OnFadeOut();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (alpha <= 0.2)
            aspeed = 0.5f;
        if(alpha >= 1.1)
            aspeed = -0.5f;

        alpha += aspeed * Time.deltaTime;
        image_start.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if ((fadeManager.GetIsFade() == -1 && fadeManager.GetAlfa() <0.0f) 
            && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0")))
        {
            audioSource.PlayOneShot(clip);
            fadeManager.OnFadeIn();
        }

        if (fadeManager.GetIsFade() == 1 && fadeManager.GetAlfa() > 1.0f)
        {
            SceneManager.LoadScene("Select New");
        }
    }
}
