using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class Q5 : MonoBehaviour
{
    public Button yourButton;

    public Text ResultDisplay;

    private AccountData AD;
    public PlayerData[] PD;

    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao5);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }

    public void Questao5(){
       Debug.Log("Resposta 5");
        var result = PD.GroupBy(i => i.platformName).Select(j => new
        {
            plat = j.Key,
            Points = j.Average(c => c.points)
        }).OrderByDescending(j => j.Points).First();
        
        
        Debug.Log( "\n\nPlataforma: " + result.plat + "\n\tMedia de pontos: " + result.Points);
        ResultDisplay.text += "\n\nPlataforma: " + result.plat + "\n\tMedia de pontos: " + result.Points;
   }
}
