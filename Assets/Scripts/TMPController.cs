using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour {
    private static TextMeshProUGUI equationBox;
    private static TextMeshProUGUI scoreboard;
    private static string equationText;
    private static string equationSymbol;

    [SerializeField] private static int score = 0;
    public static int rowCounter = 0;

    // Czy gracz dopiero zaczął 'rundę'?
    public static bool firstRun = true;

    private string activeSceneName;
    void Start() {
        activeSceneName = SceneManager.GetActiveScene().name;
        switch (activeSceneName)
        {
            case "AdditionScene": equationSymbol = "+"; break;
            case "SubtractionScene": equationSymbol = "-"; break;
            case "MultiplicationScene": equationSymbol = "×"; break;
            case "DivisionScene": equationSymbol = ":"; break;
            default: Debug.Log("Uh"); break;
        }

        equationBox = GameObject.Find("EquationBox").GetComponent<TextMeshProUGUI>();
        scoreboard = GameObject.Find("Scoreboard").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        equationBox.text = equationText;
        scoreboard.text = "Score: " + score.ToString();
    }

    public static void changeEquation(int number1, int number2) {
        equationText = number1 + " " + equationSymbol + " □ = " + number2;
        rowCounter += 1;
        // Debug.Log("Current row: " + rowCounter);
    }
    
    public static void addPoint() {
        score++;
    }

    public static void substractPoint() {
        score--;
    }
}
