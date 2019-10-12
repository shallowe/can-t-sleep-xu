using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class message_hold : MonoBehaviour
{
	private string[] simple = { "w(ﾟДﾟ)w", "(ノへ￣、)", "(￣_,￣ )", "(๑•̀ㅂ•́)و✧", "（づ￣3￣）づ╭❤～", "凸(艹皿艹 )", "φ(≧ω≦*)♪", "Hi~ o(*￣▽￣*)ブ", "︿(￣︶￣)︿", "（○｀ 3′○）", "（＊￣（エ）￣）", "┑(￣Д ￣)┍", "━┳━　━┳━", "（´Д`）", "o( =•ω•= )m", "(✿◡‿◡)", "✧(≖ ◡ ≖✿)", "○|￣|_", "ヽ(*。>Д<)o゜", "(；′⌒`)" };
	//private string[] simple = { "你好！", "好无聊阿~", "口渴", "睡不着", "生日快乐", "无不无聊", "是的", "那还用说", "生或者死，这是个问题", "但是，我拒绝", "哈哈哈哈哈哈", "-_-", "22333", "嗯", "有道理", "感觉要秃头", "hello world", "从前有座山", "很久很久以前", "故事要从我小时候.." };
	private string[] nouns = { "我", "你", "韩寒", "郭敬明", "书", "柯本", "日本", "游戏", "动漫", "白痴", "尸体", "手机", "电视", "哈姆雷特", "电脑", "毛巾", "礼物", "雨", "苹果", "太阳" };
	private string[] verbs = { "打", "讨厌", "喜欢", "导致", "促进", "缅怀", "理解", "希望", "学习", "影响", "消灭", "怕", "演奏", "引发", "抄袭", "出现", "怀疑", "失去", "选择", "值得" };
	private string[] states = { "失眠", "失恋", "变胖", "变瘦", "难过", "孤独", "开心", "肚子饿", "上厕所忘带纸", "出门忘带手机", "电脑没电", "袜子没洗", "没有游戏可以玩", "不知道看什么书", "无聊", "早起", "减肥成功", "骑自行车摔倒", "吃酸辣粉呛喉咙", "碌碌无为" };
	private string[] truths = { "提高免疫力", "睡得好", "城市不下雪", "躺在沙发", "变成大人模样", "喜欢抽烟喝酒", "跨过山和大海", "能有个归宿", "只留下苦衷", "从来未曾幸福过", "不难过", "变成巨人", "为你写首歌", "毕竟我只是我", "确实也没有", "越过山丘", "看看外面的世界", "有想哭的心情", "我只在乎你", "没关系" };
	private string[] my_tell = { "说起来有点忏愧", "全部都因为我。。。", "不知道怎么得", "就变成这样了", "也感谢你", "生日快乐", "一百六十分之一的概率", "给你的祝福", "但那都已经一去不复返了", "再见了~", "有你在的冬天总下雪", "我不知道冷", "别指望我能做到什么", "只有理所当然的事情会发生", "NEVER KNOWS BEST", "与其苟延残喘", "不如从容燃烧", "想象的心就是你的魔法", "没事，我很好", "再次，谢谢了"};
	public Transform green;
	//设置获取相关参数

	public Transform goParent;

	public GameObject itemImagePrefab;

	private Vector2 originSize;

	public Scrollbar keep;
	// Use this for initialization

	public int count;
	void Start()
	{
		count = -1;
		//获取最初goParent的宽高

		originSize = goParent.GetComponent<RectTransform>().sizeDelta;

		PlayerPrefs.SetInt("level", 3);

	}

	// Update is called once per frame

	void Update()
	{

	}
	public void OnSendMessage()
	{
		AddScrollItem(1);
		keep.value = 0;

		float speed_down = 0;
		if (count <= 100)
			speed_down= 0.088f - count * 0.00089f;
		else if (count <= 200)
			speed_down= 0.005f;
		else
		{
			game_control.Instance.need_help();
			speed_down=-4.4f;
			count = -1;
		}
		++count;

		green.position = new Vector3(green.position.x-speed_down, green.position.y, green.position.z);
		//print(count);

	}
	/*
	private float speed_down(ref int count)
	{
		if (count <= 100)
			return 0.088f - count * 0.00089f;
		else if (count <= 200)
			return 0.0012f;
		else
		{
           return -4.4f;
			count = -1;  //???为什么无法访问
		}
		++count;
		print(count);
	}
	*/
	private void AddScrollItem(int count)
	{
		string tell = null;
		int type = Random.Range(0, 8);
		switch (type)
		{
			case 0:
				tell = simple[Random.Range(0, 20)];
				break;
			case 1:
				tell = nouns[Random.Range(0, 20)] + verbs[Random.Range(0, 20)] + nouns[Random.Range(0, 20)];
				break;
			case 2:
				tell = states[Random.Range(0, 20)] + "是种什么样的体验";
				break;
			case 3:
				tell = "我最近" + states[Random.Range(0, 20)];
				break;
			case 4:
				tell = verbs[Random.Range(0, 20)] + states[Random.Range(0, 20)];
				break;
			case 5:
				tell = states[Random.Range(0, 20)] + "会导致" + truths[Random.Range(0, 20)];
				break;
			case 6:
				tell = nouns[Random.Range(0, 20)] + truths[Random.Range(0, 20)];
				break;
			case 7:
			default:
				tell = my_tell[Random.Range(0, 20)];
				break;
		}
		//生成ItemImage

		for (int i = 0; i < count; i++)
		{

			GameObject go = Instantiate(itemImagePrefab) as GameObject;
			go.transform.localScale = new Vector3(0.06f,0.06f,0.06f);

			go.transform.SetParent(goParent);
			go.GetComponentInChildren<Text>().text = tell;
			go.GetComponentInChildren<Text>().fontSize = 47;

		}

		//调整ScrollRect边框大小

		//获取当前的ItemImage的实际个数

		int itemImageCount = goParent.childCount;

		//计算当前实际生成ItemImage所需要的goParent的高度

		float ScrollRectY = itemImageCount * ((itemImagePrefab.GetComponent<RectTransform>().sizeDelta.y)

			+ goParent.GetComponent<VerticalLayoutGroup>().spacing);

		//比原先小则，保持原有尺寸不变，反之，高度设置为所需要的

		if (ScrollRectY <= originSize.y)

		{

			goParent.GetComponent<RectTransform>().sizeDelta = originSize;

		}

		else
		{

			goParent.GetComponent<RectTransform>().sizeDelta = new Vector2(originSize.x, ScrollRectY);

		}
	}

	
}
