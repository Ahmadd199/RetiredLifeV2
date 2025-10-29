using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Vector3Dis;
    public GameObject Player;
    void Start()
    {
        Vector3Dis = this.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((Player.transform.position + Vector3Dis).x>-27&& (Player.transform.position + Vector3Dis).x < 27&& (Player.transform.position + Vector3Dis).y < 16&& (Player.transform.position + Vector3Dis).y> -18)
        this.transform.position = Vector3.Lerp(this.transform.position, Player.transform.position + Vector3Dis, Time.deltaTime * 4);
    }
}
