using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_control : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] toshow;
    void Start()
    {
		int level = PlayerPrefs.GetInt("level", 0);
		print("current level  "+level);
		for(int i=0;i-1<level;++i)
		{
			toshow[i].SetActive(true);
		}

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
