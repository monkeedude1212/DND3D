using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap 
{
    Tile[,] tiles;
    int width, height;

    public TileMap(int width = 50, int height = 50)
    {
        this.width = width;
        this.height = height;
        tiles = new Tile[width, height];

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }
    }

    public int Height
    {
        get { return height; }
    }

    public int Width
    {
        get { return width; }
    }

    public Tile getTileAt(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
            return null;
        return tiles[x, y];
    }
}
