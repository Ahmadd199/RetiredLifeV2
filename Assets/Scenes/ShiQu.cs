using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiQu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Shiqu(this.GetComponent<SpriteRenderer>().sprite);
        Destroy(this.gameObject);
    }
}
