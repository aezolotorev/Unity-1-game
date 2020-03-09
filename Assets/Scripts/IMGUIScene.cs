using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Texture2D icon;
    string s;
    string sb;
    bool toggle;
    [SerializeField] private HeroControl _heroControl;
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 200, 180), "MainMenu");
        if (GUI.Button(new Rect(20, 40, 180, 30), "Open"))
            Debug.Log("Open");
        if (GUI.Button(new Rect(20, 75, 180, 30), "Save"))
            Debug.Log("Save");
        if (GUI.Button(new Rect(20, 110, 180, 30), "Load"))
            Debug.Log("Load");
        if (GUI.Button(new Rect(20, 135, 180, 30), "Restart"))
            _heroControl.ReStart();
        GUI.Label(new Rect(210, 10, 100, 30), new GUIContent("label", icon));
        s=GUI.TextField(new Rect(220, 75, 100, 30), s);
        sb= GUI.TextArea(new Rect(220, 75, 100, 30), sb);
        toggle = GUI.Toggle(new Rect(200, 110, 100, 30), toggle, "Togle");

        GUI.Box(new Rect(20, 170, 110, 20), "Life");
        GUI.Label(new Rect(20, 170, 110, 20), _heroControl.GetHP().ToString());
       
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
