using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApkController : MonoBehaviour
{
    public Text endText;

    public GameObject Walls;
    public GameObject Paints;

    public Canvas mainPanel;
    public Canvas wallPanel;
    public Canvas paintPanel;

    public InputField lenght;
    public InputField height;

    public InputField colorName;
    public InputField performance;

    public Stack<Wall> walls = new Stack<Wall>();

    public List<Paint> paints = new List<Paint>();

    public Dictionary<Wall, Paint> dictionary = new Dictionary<Wall, Paint>();

    public void WallPanelOn()
    {
        mainPanel.enabled = false;
        wallPanel.enabled = true;
    }
    public void PaintPanelOn()
    {
        mainPanel.enabled = false;
        paintPanel.enabled = true;
    }
    public void Back()
    {
        wallPanel.enabled = false;
        mainPanel.enabled = true;
    }

    public void AddWall()
    {
        Wall wall = new Wall(double.Parse(lenght.text), double.Parse(height.text));
        walls.Push(wall);
        Walls.SetActive(false);
        Paints.SetActive(true);
    }

    public void AddColor()
    {
        bool check = false;
        paints.ForEach(p =>
        {
            if(p.Color == colorName.text)
            {
                check = true;
                Wall wall2 = walls.Peek();
                var amountOfPaint2 = wall2.SurfaceArea / p.PerformancePerLiter;
                p.AmountOfPaint += amountOfPaint2;
                check = true;
                lenght.text = "";
                height.text = "";
                Paints.SetActive(false);
                colorName.text = "";
                performance.text = "";
                Walls.SetActive(true);
            }
        });
        if(!check)
        {
            Paint paint = new Paint { Color = colorName.text, PerformancePerLiter = double.Parse(performance.text) };
            Wall wall = walls.Peek();
            var amountOfPaint = wall.SurfaceArea / paint.PerformancePerLiter;
            paint.AmountOfPaint += amountOfPaint;
            paints.Add(paint);
            lenght.text = "";
            height.text = "";
            Paints.SetActive(false);
            colorName.text = "";
            performance.text = "";
            Walls.SetActive(true);
            check = false;
        } 
    }
    public void DisplayPaints()
    {
        StartCoroutine(Display());
    }

    private IEnumerator Display()
    {
        paints.ForEach(p =>
        {
            endText.text += p.Color + ": " + p.AmountOfPaint +"\n";
        });
        yield return paints;
    }


}
