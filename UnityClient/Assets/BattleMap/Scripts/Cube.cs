using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube
{
    public int x, y, height;
    public string type;
    public List<object> occupations;
    Action<Tile> typeChanged;
    Action<Tile> highlight;
    Action<Tile> unhilight;


    public Cube(int x, int y, int height = 0)
    {
        this.x = x;
        this.y = y;
        this.height = height;
    }
}
