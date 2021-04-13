using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_Add
{
    public int PointCount = 0;

    public int PointPlus(int i)
    {
        this.PointCount+=i;

        return this.PointCount;
    }
}


public class BrightnessRegulator : MonoBehaviour
{
    Material myMaterial;

    private float minEmission = 0.3f;

    private float magEmission = 20.0f;

    private int degree = 0;

    private int speed = 10;

    Color defaultColor = Color.white;

    Point_Add pc = new Point_Add();

    private GameObject PointCountText;

    // Use this for initialization
    void Start()
    {
        this.PointCountText = GameObject.Find("PointCountText");

        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            pc.PointPlus(10);
        }

        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
            pc.PointPlus(150);
        }

        else if (tag == "SmallCloudTag")
        {
            this.defaultColor = Color.cyan;
            pc.PointPlus(30);
        }

        else if (tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
            pc.PointPlus(500);
        }


        this.myMaterial = GetComponent<Renderer>().material;

        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        this.PointCountText.GetComponent<Text>().text = "得点" + pc.PointCount;

        if (this.degree >= 0)
        {
            Color emissionColor = this.defaultColor *
                (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            myMaterial.SetColor("_EmissionColor", emissionColor);

            this.degree -= this.speed;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
    }
}
