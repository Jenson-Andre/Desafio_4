using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class Q2 : MonoBehaviour
{
    public Button yourButton;
    public Text ResultDisplay;

    private AccountData AD;
    public PlayerData[] PD;


    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao2);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }
    
   public void Questao2(){
       Debug.Log("Resposta 2");
       var result = PD.Where(n => n.heroes.Count == 0).OrderBy(n => n.countryName);
       foreach(var res in result)
        {
            Debug.Log( "\nCountry: " + res.countryName + "\t\tPlayer: " + res.name);
            ResultDisplay.text += "\nCountry: " + res.countryName + "\t\tPlayer: " + res.name;
        }
   }
}
