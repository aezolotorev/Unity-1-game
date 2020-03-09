using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button _options;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    [SerializeField] private RectTransform _mainMenuPanel;
    [SerializeField] private RectTransform _optionsPanel;
    private UISound uiSound;
  
    public bool Active=false;
    void Awake()
    {
        _exit.onClick.AddListener(Exit);
        _exit.onClick.RemoveListener(Exit);
        _optionsPanel.gameObject.SetActive(false);
        _mainMenuPanel.gameObject.SetActive(false);
        //uiSound = FindObjectOfType<UISound>();
    }
    void Start()
    {
        //Получаем компонент
        uiSound = GetComponent<UISound>();
        //Используем компонент
        uiSound.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GotoOptions()
    {
        _optionsPanel.gameObject.SetActive(true); 
        _mainMenuPanel.gameObject.SetActive(false);
    }
    public void GotoMainmenu()
    {
        uiSound.OpenPanel();
        _optionsPanel.gameObject.SetActive(false);
        _mainMenuPanel.gameObject.SetActive(true);
        
    }
    public void MainEscape()
    {
        _optionsPanel.gameObject.SetActive(false);
        _mainMenuPanel.gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& Active == false)
        {
            GotoMainmenu();
            Active = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Active == true)
        {
            Active = false;
            _optionsPanel.gameObject.SetActive(false);
            _mainMenuPanel.gameObject.SetActive(false);
            return;
        }

    }
}
