using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class single_song : MonoBehaviour
{
	public Text rank;
	public GameObject number;
	public GameObject current;

	public GameObject button_on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void select_this_song()
	{
		 //      当前的歌                                                                                                        选中的歌
		if (song_manager.Instance.current_song.GetComponentInChildren<Text>().text==rank.text) //自己点自己
		{
			;
		}
		else
		{
			if (rank.text == "6"&& song_manager.Instance.current_song.GetComponentInChildren<Text>().text== "Black★Rock Shooter")
			{
				;
			}
			else
			{
				UnityEngine.UI.Image[] pics2 = this.GetComponentsInChildren<Image>();//打开现在这个 当前播放的图表
				pics2[1].enabled = true;

				UnityEngine.UI.Image[] pics = song_manager.Instance.current_song.GetComponentsInChildren<Image>(); //关闭之前那个 当前播放的图标
				pics[1].enabled = false;

				song_manager.Instance.GetComponent<AudioSource>().Stop();
				song_manager.Instance.GetComponent<AudioSource>().Play();
				song_manager.Instance.GetComponent<AudioSource>().Stop();

				song_manager.Instance.current_index = (int)float.Parse(rank.text) - 1; //换成合适的曲子
				song_manager.Instance.current_song = this.gameObject;
				song_manager.Instance.ifChange = true;
			}
		}

	}
}
