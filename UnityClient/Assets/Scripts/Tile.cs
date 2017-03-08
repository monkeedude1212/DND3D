using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile
{
    public enum TileType
    {
        Empty, 
        Floor        
    };

    TileMap tileMap;
    TileType type = TileType.Empty;
    int x, y;
    Action<Tile> typeChanged;

    public Tile(TileMap tileMap, int x, int y)
    {
        this.tileMap = tileMap;
        this.x = x;
        this.y = y;
    }

    public void registerTypeChangedCallback(Action<Tile> callback)
    {
        typeChanged += callback;
    }

    public void unregisterTypeChangedCallback(Action<Tile> callback)
    {
        typeChanged -= callback;
    }

    public TileType Type
    {
        get { return type; }
        set 
        {
            if (type == value)
                return;

            type = value;
            if (typeChanged != null)
                typeChanged(this);
        }
    }

    public int Y
    {
        get { return y; }
    }

    public int X
    {
        get { return x; }
    }
}
