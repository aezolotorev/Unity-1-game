using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{

    [SerializeField] private Button Text;

    [SerializeField] private RectTransform _p;
    [SerializeField] private string[] _alltext;
    private int i=0;
    [SerializeField] private Text _enemyText;
    [SerializeField] private Text _heroText;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _hero;

    
    void Awake()
    {
       
        Time.timeScale = 0;
        NextText();
    }
    public void NextText()
    {
        if (i % 2 == 0)
        {
            _heroText.gameObject.SetActive(false);
            _hero.SetActive(false);
            _enemy.SetActive(true);
            _enemyText.gameObject.SetActive(true);
            _enemyText.text = _alltext[i];
        }

        else
        {
            _enemyText.gameObject.SetActive(false);
            _enemy.SetActive(false);
            _hero.SetActive(true);
            _heroText.gameObject.SetActive(true);
            _heroText.text = _alltext[i];

        }
        i++;
        if (i == _alltext.Length - 1)
        {
            StartGame();           
        }
        
    }
    
    
    
    
    
    public void StartGame()
    {
        _enemyText.gameObject.SetActive(false);
        _enemy.SetActive(false);
        _hero.SetActive(false);
        _heroText.gameObject.SetActive(false);
        _p.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
