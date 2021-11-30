using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    public TextAsset data;

    [System.Serializable]
    public class players{
        public int id;
        public string name;
        public string email;
        public string username;
        public int points;
        public int platformIndex;
        public string platformName;
        public int countryIndex;
        public string countryName;
        public string[] heroes;

    }

        [System.Serializable]
        public class heroes{
        public int id;
        public string name;
        public int level;
        public string heroClassIndex;
        public string heroClassName;
        public int gold;

    }

    [System.Serializable]
    public class PlayersList{
        public players[] players;
    }

    [System.Serializable]
    public class HeroesList{
        public players[] heroes;
    }

    public PlayersList myPlayerList = new PlayersList();
    public HeroesList myHeroesList = new HeroesList();
    // Start is called before the first frame update
    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayersList>(data.text);
        myHeroesList = JsonUtility.FromJson<HeroesList>(data.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
