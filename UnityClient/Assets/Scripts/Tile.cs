﻿using System.Collections;
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

    TileMap tileMap = null;
    TileType type = TileType.Empty;
    int x, y;
    Action<Tile> typeChanged;
    Action<Tile> select;
    Action<Tile> deselect;
    bool selected = false;

    public Tile(TileMap tileMap, int x, int y)
    {
        this.tileMap = tileMap;
        this.x = x;
        this.y = y;
    }

    public void RegisterSelectedCallback(Action<Tile> callback)
    {
        select += callback;
    }

    public void DeregisterSelectedCallback(Action<Tile> callback)
    {
        select -= callback;
    }

    public void RegisterDeselectedCallback(Action<Tile> callback)
    {
        deselect += callback;
    }

    public void DeregisterDeselectedCallback(Action<Tile> callback)
    {
        deselect -= callback;
    }

    public void RegisterTypeChangedCallback(Action<Tile> callback)
    {
        typeChanged += callback;
    }

    public void DeregisterTypeChangedCallback(Action<Tile> callback)
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

    public bool Selected
    {
        get { return selected; }
        set
        {
            if (selected == value)
                return;

            if (select != null)
            {
                if (selected)
                    deselect(this);
                else
                    select(this);
            }
            selected = value;
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
