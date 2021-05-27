using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private bool isLoad;
    [SerializeField] private bool isSave;
    [SerializeField] private bool isDelete;
    [SerializeField] private bool isClear;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoad)
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            Load(loadScene.name);
        }
        if (isSave)
        {
            Save();
        }
        if (isDelete)
        {
            AllDelete();
        }
        if (isClear)
        {
            AllClear();
        }
    }

    //ゲームクリア時に呼び出し
    public void Save()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        //シーンの名前をキーにセーブ
        PlayerPrefs.SetInt(loadScene.name, 1);
        PlayerPrefs.Save();
    }

    public int Load(string name)
    {
        int key;
        key = PlayerPrefs.GetInt(name, 0);
        return key;
    }

    public void SaveSceneName()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        //シーンの名前をキーにセーブ
        PlayerPrefs.SetString("scenename",loadScene.name);
        PlayerPrefs.Save();
    }

    public string LoadSceneName()
    {
        string name;
        name = PlayerPrefs.GetString("scenename", "");
        return name;
    }

    public void AllDelete()
    {
        PlayerPrefs.DeleteAll();
    }

    public void AllClear()
    {
        PlayerPrefs.SetInt("Stage1", 1);
        PlayerPrefs.SetInt("stage2", 1);
        PlayerPrefs.SetInt("stage3", 1);
        PlayerPrefs.SetInt("stage4", 1);
        PlayerPrefs.SetInt("stage5", 1);
        PlayerPrefs.SetInt("stage6", 1);
        PlayerPrefs.SetInt("stage7", 1);
        PlayerPrefs.SetInt("stage8", 1);
        PlayerPrefs.SetInt("stage9", 1);
        PlayerPrefs.Save();
    }
}
