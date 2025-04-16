using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportScene : MonoBehaviour
{

    public string sceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
