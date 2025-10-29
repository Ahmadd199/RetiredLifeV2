using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagManager : MonoBehaviour
{
    [System.Serializable]
    public struct Fish
    {
        public int Type;
        public Sprite sprite;
        public int NumBer;
        public int Value;
    }
    [SerializeField]
    public List<Fish> AllFish = new List<Fish>();
    public GameObject[] Show;

    public int ThisYong;
    public GameObject Player1;

    public InputField inputField1;

    public GameObject Fish1;

    public int Gold;

    public int ThisYongNum;

    public GameObject Bagshow;

    public static BagManager bagManager;

    public int[] AllValue;

    public Text textgold;
    private void Awake()
    {
        if (bagManager == null)
        {
            bagManager = this;
        }
    }
    public void Add(int t,Sprite sprite)
    {
        int temp=0;
        for (int i = 0; i < BagManager.bagManager.AllFish.Count; i++)
        {
            if (BagManager.bagManager.AllFish[i].Type == t)
            {
                Fish fishtemp = AllFish[i];
                fishtemp.NumBer += 1;
               
                AllFish[i] = fishtemp;
                temp = 1;
            }
        }
        if (temp == 0)
        {
            Fish fishtemp = new Fish();
            fishtemp.NumBer = 1;
            fishtemp.sprite = sprite;
            fishtemp.Type = t;
            fishtemp.Value = AllValue[t];
            AllFish.Add(fishtemp);
        }

        ShowBag();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindGameObjectWithTag("Player");
    }
   
    // Update is called once per frame
    void Update()
    {
        textgold.text = "Gold:" + Gold.ToString();
        if (Input.GetKeyDown(KeyCode.B))
        {
            Bagshow.SetActive(!Bagshow.activeSelf);
            ShowBag();
        }
    }
    public void Yong(int t)
    {
        ThisYongNum = t;
        Show[0].SetActive(true);
        if (Player.IsNpc)
        {
            Show[0].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Show[0].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void Yong1(int t)
    {
        ThisYong = t;
        Show[1].SetActive(true);
    }
    public void Sure()
    {
        if (inputField1.text == null)
        {
            return;
        }
        int t = int.Parse(inputField1.text);
        if (t == 0)
        {
            return;
        }
        int temp = 0;
        if (AllFish[ThisYongNum].NumBer >= t)
        {
            temp = t;
        }
        else
        {
            temp = AllFish[ThisYongNum].NumBer;
        }
        if (ThisYong == 0)
        {

            for (int i = 0; i < temp; i++)
            {
              GameObject gameObjectfish=  GameObject.Instantiate(Fish1, Player1.transform.GetChild(0).GetChild(Random.Range(0, Player1.transform.GetChild(0).childCount)).transform.position, Quaternion.identity);
                gameObjectfish.GetComponent<SpriteRenderer>().sprite = AllFish[ThisYongNum].sprite;
            }
        }
        else
        {
            Gold += temp * AllFish[ThisYongNum].Value;





        }

        Fish fishtemp = AllFish[ThisYongNum];
        fishtemp.NumBer -= t;
        if (fishtemp.NumBer <= 0)
        {
            AllFish.RemoveAt(ThisYongNum);
        }
        else
        {
            AllFish[ThisYongNum] = fishtemp;
        }
        ShowBag();
    }
    public void ShowBag()
    {
        for (int i = 0; i < 32; i++)
        {
            if (i < AllFish.Count)
            {
                Bagshow.transform.GetChild(i).gameObject.SetActive(true);
                Bagshow.transform.GetChild(i).GetComponent<Image>().sprite = AllFish[i].sprite;
                Bagshow.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = AllFish[i].NumBer.ToString();
            }
            else
            {
                Bagshow.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
}
