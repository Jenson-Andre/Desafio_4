using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class Q1 : MonoBehaviour
{
    public GameObject Database;
    public Button yourButton;

    public Text ResultDisplay;

    public List<int> Resposta = new List<int>();

    private AccountData AD;
    public PlayerData[] PD;

    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao1);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }
    
   public void Questao1(){
       Debug.Log("Resposta 1");
       var result = PD.OrderByDescending(n => n.points).Where((n, i) => i <= 2);
       foreach(var res in result)
        {
            Debug.Log( "\nPoints: " + res.points + "\t\tName: " + res.name);
            ResultDisplay.text += "\nPoints: " + res.points + "\t\tName: " + res.name;
        }
   }
}
