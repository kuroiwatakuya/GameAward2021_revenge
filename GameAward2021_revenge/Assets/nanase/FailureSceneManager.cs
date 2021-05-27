using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureSceneManager : MonoBehaviour
{
    private GameObject TurnManager;      //�^�[���}�l�[�W���[�i�[
    private TurnManager TurnMng;         //�^�[���}�l�[�W���[�̃X�N���v�g�󂯎��
    private SaveManager saveManager;

    private int TurnNum;                   //���݃^�[�����l

    // Start is called before the first frame update
    void Start()
    {
        TurnManager = GameObject.FindWithTag("GameManager");
        TurnMng = TurnManager.gameObject.GetComponent<TurnManager>();
        saveManager = TurnManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnNum = TurnMng.GetTurnCount();                       //�ő�^�[�������l�i�[

        if(TurnNum<=0)
        {
            saveManager.SaveSceneName();
            SceneManager.LoadScene("GameOver");
        }
    }
}
