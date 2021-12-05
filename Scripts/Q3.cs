﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System.IO;

public class Q3 : MonoBehaviour
{
    public Button yourButton;
    public Text ResultDisplay;

    private AccountData AD;
    public PlayerData[] PD;


    private void Start() {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(Questao3);
        string str1 = File.ReadAllText(Application.dataPath + "/Scripts/data4.json");
        var saved = JsonUtility.FromJson<AccountData>(str1);

        AD = saved;
        PD = AD.players;
    }

    public void Questao3(){
       Debug.Log("Resposta 3");
       List<HeroData> HD = new List<HeroData>();

        var result = PD.Select(n => n.heroes).Aggregate(HD,(ci, h) =>
        {
            ci.AddRange(h.ToArray());
            return ci;
        }).ToList();


        var result1 = HD.GroupBy(i => i.heroClassIndex)
                .Select(j => new
                {
                    heroclass = j.Key,
                    count = j.Count()
                }).ToList().OrderByDescending(n => n.count).First();
      
        
        Debug.Log( "\nClasse: " + result1.heroclass  + "\t\tContagem: " +result1.count);
        ResultDisplay.text += "\nClasse: " + result1.heroclass  + "\t\tContagem: " +result1.count;
   }
}
