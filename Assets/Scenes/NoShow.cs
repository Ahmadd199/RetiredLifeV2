using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShow : MonoBehaviour
{
    // Start is called before the first frame update
    float Showtime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Showtime += Time.deltaTime;
        if (Showtime >= 1.5f)
        {
            Showtime = 0;
            this.gameObject.SetActive(false);
        }
    }
}
