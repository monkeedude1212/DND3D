using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    enum TileType
    {
        Dirt,
        Empty
    };

    TileType type = TileType.Empty;
    World world;
    int x, y;

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }   
}
