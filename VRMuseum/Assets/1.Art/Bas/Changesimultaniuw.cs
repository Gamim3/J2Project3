using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changesimultaniuw : MonoBehaviour
{
    public float gradientControll;

    public Material floor;
    public Material Foliage;
    public Material hek;
    public Material house;
    public Material houseE;
    public Material Leaves;

    // Update is called once per frame
    void Update()
    {
        //floor.SetFloat("_GradientControllFloat", gradientControll);
        Foliage.SetFloat("_GradientControllFloat", gradientControll);
        hek.SetFloat("_GradientControllFloat", gradientControll);
        house.SetFloat("_GradientControllFloat", gradientControll);
        houseE.SetFloat("_GradientControllFloat", gradientControll);
        Leaves.SetFloat("_GradientControllFloat", gradientControll);
    }
}
