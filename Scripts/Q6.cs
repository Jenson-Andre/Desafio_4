using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class Q6 : MonoBehaviour
{
    public Button yourButton;

    public Text ResultDisplay;

    private AccountData AD;
    public PlayerData[] PD;

    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao6);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }

    public void Questao6(){
       Debug.Log("Resposta 6");
        var result = PD.OrderByDescending(n => n.heroes.Sum(m => m.gold)).Take(10);


        foreach (var res in result)
        {
            Debug.Log( "\nGold: " + res.heroes.Sum(m => m.gold) + "\t\tPlayer: " +res.name);
            ResultDisplay.text += "\nGold: " + res.heroes.Sum(m => m.gold) + "\t\tPlayer: " +res.name;
        }
   }
}
