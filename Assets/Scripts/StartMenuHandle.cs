using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMenuHandle : MonoBehaviour
{
    public TMP_InputField inputName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        GameManager.Instance.playerName = inputName.text;
        GameManager.Instance.LoadMainScene();
    }
}
