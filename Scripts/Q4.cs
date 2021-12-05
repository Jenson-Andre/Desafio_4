using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;


public class Q4 : MonoBehaviour
{
    public Button yourButton;
    public Text ResultDisplay;

    private AccountData AD;
    public PlayerData[] PD;


    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao4);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }

    public void Questao4(){
       Debug.Log("Resposta 4");
        var result = PD.GroupBy(n => n.countryName).Select(group => new
        {
            country = group.Key,
            Count = group.Count()
        }).OrderByDescending(x => x.Count).First();


        Debug.Log( "\nContagem: " + result.Count + "\t\t País: " + result.country);
        ResultDisplay.text += "\nContagem: " + result.Count + "\t\t País: " + result.country;
   }
}
