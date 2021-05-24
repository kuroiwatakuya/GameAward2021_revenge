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

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        image_select = ClearSelectUI.GetComponent<Image>();
        image_next = ClearNextUI.GetComponent<Image>();

        gameManager = GameObject.FindWithTag("GameManager");
        SaveManager = gameManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
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
            if (num == 1)
                SceneManager.LoadScene("Select");
            if (num == 0)
            {
                if (SaveManager.Load("stage4") > 0)
                    SceneManager.LoadScene("stage5");

                if (SaveManager.Load("stage3") > 0)
                    SceneManager.LoadScene("stage4");

                if (SaveManager.Load("stage2") > 0)
                    SceneManager.LoadScene("stage3");

                if (SaveManager.Load("Stage1") > 0)
                    SceneManager.LoadScene("stage2");

                SceneManager.LoadScene("Stage1");
            }
        }
    }


}
