using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private PlatesManager platesManager;
    private Transform sushi;
    private int plateIndex = 0;
    void Start()
    {
        sushi = transform.parent;
        platesManager = sushi.parent.GetComponent <PlatesManager>();
        sushi.GetComponent<UIEventTrigger>().onDragEnd.Add(new EventDelegate(OnDragEnd));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "plate")
        {
            plateIndex = int.Parse(collision.transform.Find("index").GetComponent<UILabel>().text);
        }
    }

    private void OnDragEnd()
    {
        print("plateIndex  " + plateIndex);
        //sushi.localPosition = new Vector3(platesManager.plates[plateIndex].localPosition.x, 
        //    platesManager.plates[plateIndex].localPosition.y + 10, 0);
        int sushiIndex = int.Parse(sushi.Find("index").GetComponent<UILabel>().text);
        print("sushi  " + sushiIndex);
        platesManager.ReplaceSushis(plateIndex, sushiIndex);
        //sushi.Find("index").GetComponent<UILabel>().text = plateIndex.ToString();
    }
}
