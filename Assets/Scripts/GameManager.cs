using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int settingsFlag;

    bool[] effects;
    
    void Awake()
    {
        if (instance == null)
        {
            effects = new bool[4];
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator EnterPlayRoutine()
    {
        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        yield return 0.5f;
        Debug.Log("Before spawning");
        Debug.Log("After spawning");
        FindObjectOfType<Controller>().Init();
        Debug.Log("After controller Init");
    }
    
    public IEnumerator EnterStatsRoutine()
    {
        yield return SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

}
