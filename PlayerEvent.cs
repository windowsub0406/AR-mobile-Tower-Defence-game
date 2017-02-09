using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerEvent : MonoBehaviour {
    public Text HPText = null;
    public string tmp_hp;

	// Use this for initialization
	void Start () {
        HP_Manager(100);
	}

    public void HP_Manager(int hp)
    {
        tmp_hp = hp.ToString();
        HPText.text = "HP : " + tmp_hp;
    }
}
