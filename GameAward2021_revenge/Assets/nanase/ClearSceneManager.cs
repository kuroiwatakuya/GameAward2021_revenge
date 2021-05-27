using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneManager : MonoBehaviour
{
    private GameObject gameManager;
    private SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        saveManager = gameManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            saveManager.SaveSceneName();
            saveManager.Save();
            SceneManager.LoadScene("ClearScene");
        }
    }
}
