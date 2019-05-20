using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public double WallLenght { get; set; }

    public double WallHeight { get; set; }

    public double SurfaceArea { get; set; }

   

    public Wall(double lenght, double height)
    {
        WallLenght = lenght;
        WallHeight = height;
        SurfaceArea = WallLenght * WallHeight;
    }

    
}
