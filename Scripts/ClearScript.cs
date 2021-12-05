using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour
{
    public Button yourButton;

    public Text ResultDisplay;
    
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(ClearResult);
    }

    public void ClearResult(){
        ResultDisplay.text = "Resultado";
    }
}
