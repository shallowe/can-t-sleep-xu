using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class song_manager : MonoBehaviour
{
	public GameObject line;

	public int current_loud = 5;
	private float[] local_lund = { 0f, 0.12f, 0.19f, 0.28f, 0.37f, 0.48f, 0.57f, 0.66f, 0.72f, 0.81f, 1f };
	public GameObject sound_show;
	public GameObject sound_show_holder;

	public GameObject phone_close;
	public Slider audioTimeSlider;
	public GameObject current_song;
	public bool ifChange = false;
	public Text song_name;

	public AudioClip[] clips;
	public int current_index=0;

	public GameObject button_on;
	private static song_manager _instance;
	public static song_manager Instance
	{
		get
		{
			return _instance;
		}
	}
	void Awake()
	{
		_instance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
		this.GetComponent<AudioSource>().clip = clips[0];
		PlayerPrefs.SetInt("level", 4);

		/*
		audioTimeSlider.onValueChanged.AddListener(
			(delegate
			{
				SetAudioTimeValueChange();
			})
			);
		*/
	}

    // Update is called once per frame
    void Update()
    {
		if(ifChange)
		{
			UnityEngine.UI.Text []song = current_song.GetComponentsInChildren<Text>();
			if (song[1].text == "Black★Rock Shooter")
				song_name.text = "生日快乐，友谊干杯";
			else
				song_name.text = song[1].text;

			music_change(current_index);

			ifChange = false;
		}
		else
		{
			//AudioSource audioSource = current_song.GetComponentInChildren<AudioSource>();
			audioTimeSlider.value = this.GetComponent<AudioSource>().time / this.GetComponent<AudioSource>().clip.length;
		}
    }
	public void button_stop()
	{
		this.GetComponent<AudioSource>().Stop();
		button_on.SetActive(false);
	}
	public void button_pause()
	{
		this.GetComponent<AudioSource>().Pause();
		button_on.SetActive(false);
	}
	public void music_change(int index)
	{
		this.GetComponent<AudioSource>().clip = clips[index];
		this.GetComponent<AudioSource>().Play();
		button_on.SetActive(true);
	}
	public void button_begin()
	{
		this.GetComponent<AudioSource>().Play();
		button_on.SetActive(true);
	}
	public void button_close()
	{
		if (phone_close.activeSelf == false)
			phone_close.SetActive(true);
		else
			phone_close.SetActive(false);
	}
	public void button_loud()
	{
		if(current_loud<=9)
		{
			current_loud += 1;
			this.GetComponent<AudioSource>().volume = local_lund[current_loud];
			if (phone_close.activeSelf == false)
			{
				GameObject one = GameObject.Instantiate(sound_show, sound_show_holder.transform);
				one.transform.localScale = new Vector3(1f, 1f, 1f);
				one.GetComponent<Slider>().value = local_lund[current_loud];
				Destroy(one, 3f);
			}
		}
	}
	public void button_quied()
	{
		if(current_loud>1)
		{
			current_loud -= 1;
			this.GetComponent<AudioSource>().volume = local_lund[current_loud];
			if(phone_close.activeSelf==false)
			{
				GameObject one = GameObject.Instantiate(sound_show, sound_show_holder.transform);
				one.transform.localScale = new Vector3(1f, 1f, 1f);
				one.GetComponent<Slider>().value = local_lund[current_loud];
				Destroy(one, 3f);
			}
		}
	}
	public void line_click()
	{
		line.transform.DOLocalMoveY(-500f, 6f);
		game_control.Instance.WinGame4();
		this.GetComponent<AudioSource>().volume =0;
	}
	private void SetAudioTimeValueChange()
	{
		/*
		AudioSource audioSource = current_song.GetComponentInChildren<AudioSource>();
		audioSource.time = audioTimeSlider.value * audioSource.clip.length;
		*/

		//this.GetComponent<AudioSource>().time = audioTimeSlider.value * this.GetComponent<AudioSource>().clip.length;

	}
}
