using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager instance;

    public Launcher launcher;

    private int score;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        score = 0;
        launcher.ChangeTool(Launcher.LauncherTool.Arrow);
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.C)) {
            launcher.ChangeTool(Launcher.LauncherTool.Cannon);
            Invoke("BackToBallLauncher", 4);
        }
        
    }

    public void AddPoints(int points) {
        score += points;
    }

    private void BackToBallLauncher() {
        launcher.ChangeTool(Launcher.LauncherTool.Arrow);
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 150,30), score+"");
    }

}
