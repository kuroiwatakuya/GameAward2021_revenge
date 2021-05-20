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
            // ���݂�Scene�����擾����
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

    //�Q�[���N���A���ɌĂяo��
    public void Save()
    {
        // ���݂�Scene�����擾����
        Scene loadScene = SceneManager.GetActiveScene();
        //�V�[���̖��O���L�[�ɃZ�[�u
        PlayerPrefs.SetInt(loadScene.name, 1);
        PlayerPrefs.Save();
    }

    public int Load(string name)
    {
        int key;
        key = PlayerPrefs.GetInt(name, 0);
        return key;
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
        PlayerPrefs.Save();
    }
}
