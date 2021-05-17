using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseText : MonoBehaviour
{
    public GameObject pause_object = null;
    private GameObject PauseObject;
    private PauseManager PauseManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text pause_text = pause_object.GetComponent<Text>();


        PauseObject = GameObject.FindWithTag("GameManager");
        PauseManagerScript = PauseObject.GetComponent<PauseManager>();

        // テキストの表示を入れ替える
        if (PauseManagerScript.GetSelectingScene() == 0)
        {
            pause_text.text = "タイトルに戻る";
        }
        if (PauseManagerScript.GetSelectingScene() == 1)
        {
            pause_text.text = "リスタート";
        }
        if (PauseManagerScript.GetSelectingScene() == 2)
        {
            pause_text.text = "セレクトに戻る";
        }
    }
}