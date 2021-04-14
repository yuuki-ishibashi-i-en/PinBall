using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;

    private GameObject PointCountText;

    private int Point =0;

    // Use this for initialization
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.PointCountText = GameObject.Find("PointCountText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            Point += 10;
        }

        if (other.gameObject.tag == "LargeStarTag")
        {
            Point += 50;
        }

        if (other.gameObject.tag == "SmallCloudTag")
        {
            Point += 40;
        }

        if (other.gameObject.tag == "LargeCloudTag")
        {
            Point += 200;
        }

        this.PointCountText.GetComponent<Text>().text = "得点" + Point;
    }
}
