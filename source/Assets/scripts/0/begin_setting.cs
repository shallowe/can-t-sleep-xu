using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begin_setting : MonoBehaviour
{
	public GameObject about;
	public GameObject choose;
    // Start is called before the first frame update
    void Start()
    {
		game_control.Instance.init();
		if (PlayerPrefs.GetInt("level", 0) != 0)
		{
			   choose.SetActive(true);
		}
		if(PlayerPrefs.GetInt("level",0)==6)
		{
			about.SetActive(true);
		}
			
    }

    // Update is called once per frame
    void Update()
    {

    }
}
