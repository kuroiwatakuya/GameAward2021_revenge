using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class LightingScript : MonoBehaviour
{

    private GameObject m_GameManager;
    private TurnManager m_TurnManager;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientIntensity = 1.0f;
        RenderSettings.reflectionIntensity = 1.0f;

        m_GameManager = GameObject.FindWithTag("GameManager");
        m_TurnManager = m_GameManager.GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_TurnManager.GetEnvironment() == 1)
        {
            RenderSettings.ambientIntensity = 1.0f;
            RenderSettings.reflectionIntensity = 1.0f;
        }
        else
        {
            RenderSettings.ambientIntensity = 0.0f;
            RenderSettings.reflectionIntensity = 0.0f;
        }
    }
}
