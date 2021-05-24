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

    void Start()
    {
        alpha = 1.0f;
        aspeed = -0.5f;
        image_start = TitlestartUI.GetComponent<Image>();
    }

    void Update()
    {
        if (alpha <= 0.2)
            aspeed = 0.5f;
        if(alpha >= 1.1)
            aspeed = -0.5f;

        alpha += aspeed * Time.deltaTime;
        image_start.color = new Color(1.0f, 1.0f, 1.0f, alpha);

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("Select");
        }
    }
}
