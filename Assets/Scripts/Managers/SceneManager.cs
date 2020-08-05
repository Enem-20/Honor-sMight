using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Button Game;
    [SerializeField] private Button ChooseLevel;
    [SerializeField] private Button Exit;

    [SerializeField] private Button[] Levels;

    string Level1 = "Level1";

    
    // Start is called before the first frame update
    private void Awake()
    {
        Application.LoadLevel("Menu");
    }

    void Start()
    {
        Game.onClick.AddListener(GameOnClick);
        ChooseLevel.onClick.AddListener(ChooseLevelOnClick);
        Exit.onClick.AddListener(ExitOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        
    }

    void GameOnClick()
    {
        Application.LoadLevel("Level1");
    }
    void ChooseLevelOnClick()
    {

    }
    void ExitOnClick()
    {
        Application.Quit();
    }
    
}
