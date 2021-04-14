using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointAdd
{
    public int PointCount = 0;

    public int PointPlus(int i)
    {
        this.PointCount += i;

        return this.PointCount;
    }
}

public class PointControl : MonoBehaviour
{

    private GameObject PointCountText;

    PointAdd pc = new PointAdd();

    // Start is called before the first frame update
    void Start()
    {
        this.PointCountText = GameObject.Find("PointCountText");

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            pc.PointPlus(10);
        }

        if (other.gameObject.tag == "LargeStarTag")
        {
            pc.PointPlus(50);
        }

        if (other.gameObject.tag == "SmallCloudTag")
        {
            pc.PointPlus(40);
        }

        if (other.gameObject.tag == "LargeCloudTag")
        {
            pc.PointPlus(200);
        }

        this.PointCountText.GetComponent<Text>().text = "得点" + pc.PointCount;

    }
}