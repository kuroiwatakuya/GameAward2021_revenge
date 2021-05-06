using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int SaveNum;

    // Start is called before the first frame update
    void Start()
    {
        SaveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Load();
        }
    }

    public void Save(int savenum)
    {

        PlayerPrefs.SetInt("セーブポイントは", savenum);
        PlayerPrefs.Save();
        Debug.Log("セーブするよ" + savenum);
    }

    public void Load()
    {
        Debug.Log("ロードするよ");
        SaveNum = PlayerPrefs.GetInt("セーブポイント", 0);
        Debug.Log("セーブポイントは" + SaveNum);
    }
}
