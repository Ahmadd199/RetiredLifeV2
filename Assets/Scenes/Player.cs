using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float Speed;
    public bool Diao;
    public bool WaitDiao;
    public bool CanDiao;

    public float DiaoTime;

    public Text Text1;
    public Image FishShow;
    public Sprite[] spritesFish;
    public int ThisType;


    public static bool IsNpc;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shiqu(Sprite sprite) 
    {
        for (int i = 0; i < spritesFish.Length; i++)
        {
            if (sprite == spritesFish[i])
            {
                BagManager.bagManager.Add(i, sprite);
                return;
            }
        }
    
    }
    public void EndDiao() 
    {
        Diao = false;
        if(DiaoTime<5)
        {
            Text1.text = "Unfortunately, You didn't catch any fish";
            Text1.gameObject.SetActive(true);
        }
        else
        {
            Text1.text = "Congratulations on catching a fish";
            Text1.gameObject.SetActive(true);
            ThisType = Random.Range(0, spritesFish.Length);
            FishShow.sprite = spritesFish[ThisType];
            FishShow.gameObject.SetActive(true);
            BagManager.bagManager.Add(ThisType, spritesFish[ThisType]);
        }
        DiaoTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Diao)
        {
            if (WaitDiao)
            {
                DiaoTime += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.K))
                {
                    WaitDiao = false;
                    this.transform.GetComponent<Animator>().SetInteger("State", 3);
                   
                    Invoke("EndDiao", 0.8f);
                }
            }
            
           

        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector2.up * Time.deltaTime * Speed);

                this.transform.GetComponent<Animator>().SetInteger("State", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(-Vector2.up * Time.deltaTime * Speed);

                this.transform.GetComponent<Animator>().SetInteger("State", 1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.localEulerAngles = new Vector3(0, 180, 0);
                this.transform.Translate(Vector2.right * Time.deltaTime * Speed);

                this.transform.GetComponent<Animator>().SetInteger("State", 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.localEulerAngles = new Vector3(0, 0, 0);
                this.transform.Translate(Vector2.right * Time.deltaTime * Speed);

                this.transform.GetComponent<Animator>().SetInteger("State", 1);
            }
            else
            {
                this.transform.GetComponent<Animator>().SetInteger("State", 0);
                if (Input.GetKeyDown(KeyCode.J) && CanDiao)
                {
                    Diao = true;
                    WaitDiao = true;
                    this.transform.localEulerAngles = new Vector3(0, 180, 0);
                    this.transform.GetComponent<Animator>().SetInteger("State", 2);
                }
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="CanFish")
        {
            CanDiao = true;
        }
        if (other.tag == "NPC")
        {
            IsNpc = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CanFish")
        {
            CanDiao = false;
        }
        if (collision.tag == "NPC")
        {
            IsNpc = false;
        }
    }
}
