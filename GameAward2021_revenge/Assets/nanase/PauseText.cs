using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseText : MonoBehaviour
{
    [SerializeField] private GameObject PauseSelectUI;
    private Image image_select;
    [SerializeField] private GameObject PauseStartUI;
    private Image image_start;
    [SerializeField] private GameObject PauseReStartUI;
    private Image image_restart;
    
    private GameObject PauseObject;
    private PauseManager PauseManagerScript;
   

    // Start is called before the first frame update
    void Start()
    {
        image_select = PauseSelectUI.GetComponent<Image>();
        image_start = PauseStartUI.GetComponent<Image>();
        image_restart = PauseReStartUI.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

        image_select.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_start.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        image_restart.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);


        PauseObject = GameObject.FindWithTag("GameManager");
        PauseManagerScript = PauseObject.GetComponent<PauseManager>();

        // テキストの表示を入れ替える
        if (PauseManagerScript.GetSelectingScene() == 0)
        {
            image_restart.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        if (PauseManagerScript.GetSelectingScene() == 1)
        {
            image_select.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        if (PauseManagerScript.GetSelectingScene() == 2)
        {
            image_start.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}