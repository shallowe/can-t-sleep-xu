using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class game_control : MonoBehaviour
{

	public int score = 0;
	public float speed = 5;
	private static game_control _instance;
	public GameObject sleep_head;
	public bool ifWin = false;

	public Text helpful;

	static public int currentLevel;
	public Image win_title;

	public GameObject begin_title;
	private string[] begin_tell={"突然某天，阿豪发现他失眠了，但是他马上想到了办法，那就是外国人擅长的办法....数羊\n使用键盘点击左下角的按钮 跳 来帮助阿豪数羊","今晚，他又失眠了，因为他构思出了一款特别棒的游戏，有创意的玩法，爽快的射击体验，这都让他在想象中无法自拔\n 使用按键wasd控制飞机的移动\n用  j  控制飞机的射击","今晚，阿豪躺在床上陷入沉思，难道。。是我的睡姿不正确，导致我睡不着?\n 使用按键wasd来切换不同的状态，以发现最舒服的睡姿","阿豪最近喜欢在睡前用手机和自己的qq小号聊天，以此消耗白天没有用完的体力，实现入眠的目的\n 使用鼠标点击 发送 按钮发送消息，以此消耗体力","听说睡前听安静的歌有助于入眠，所以最近阿豪喜欢带着耳机，听歌到深夜。\n使用鼠标点击歌曲来听不同的歌曲,发现催眠效果最好的歌"};
	private string[] help_tell = { "数着数着，他开始思考  羊  和 睡 到底有什么关系", "越打越激动，激动得他难以入眠,以致无法好好欣赏这片星空", "频繁的换睡姿让他睡意全无", "在手机屏幕前，阿豪的精力就好像用不完" };
	public static game_control Instance
	{
		get
		{
			return _instance;
		}
	}
    // Start is called before the first frame update
	void Awake()
	{
		_instance = this;
	}
    void Start()
    {
		begin_title.SetActive(true);
		if(currentLevel>0)
		   gameBegin();
    }
    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			toGame(0);
		}
    }
	public void init()
	{
		currentLevel = 0;
	}
	public void need_help()
	{
		helpful.text = help_tell[currentLevel-1];
	}
	private void gameBegin()
	{
		print(currentLevel);
		if (currentLevel > 0&&currentLevel<6)
		{
			begin_title.GetComponentInChildren<Text>().DOText(begin_tell[currentLevel - 1], (float)begin_tell[currentLevel - 1].Length / 4);
			Destroy(begin_title, (float)begin_tell[currentLevel - 1].Length / 4 + 1.0f);
		}
	}
	
	public void onClickBegin()
	{
		toGame(1);
	}
	public void onClickChoose()
	{
		toGame(8);
	}
	public void onClickAbout()
	{
		toGame(7);
	}
	public void toGame(int level)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(level);
		currentLevel = level;
	}
	public void OnStill()
	{
		   score += 1;
	}
	public void OnMove()
	{
		score = 0;
	}
	public void WinGame4()
	{
		win_title.transform.DOLocalMove(new Vector3(0, -15, 1), 3f);
	}
	public void WinGame3()
	{
		win_title.transform.DOLocalMove(new Vector3(0, -15, 1), 0f);
	}
	public void WinGame2()
	{
		win_title.transform.DOLocalMove(new Vector3(0, -15, 0), 0f);
		sleep_head.SetActive(false);
		ifWin = true;
	}
	// game 1
	public void OnScoreChange()
	{
		Text to_change = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
		to_change.text = "" + score;
	}
	public void WinGame()
	{
		sleep_head.SetActive(true);
		ifWin = true;

		win_title.transform.DOLocalMove(new Vector3(0, -15, 0),3f);
	}
	public void next_level()
	{
		toGame(currentLevel+1);
		//UnityEngine.SceneManagement.SceneManager.LoadScene(++currentLevel);
	}
	public void back()
	{
		toGame(0);
		//UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
