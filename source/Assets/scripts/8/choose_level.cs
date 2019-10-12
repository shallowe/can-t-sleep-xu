using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choose_level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void onClick(int level)
	{
		int num = (int)float.Parse(GetComponent<Text>().text);
		game_control.Instance.toGame(num);
	}
}
