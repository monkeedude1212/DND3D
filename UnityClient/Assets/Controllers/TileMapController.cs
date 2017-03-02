using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapController : MonoBehaviour
{
    public Sprite defaultTileSprite;
    TileMap tileMap;

    void Start()
    {
        tileMap = new TileMap();
        for (int x = 0; x < tileMap.Width; ++x)
        {
            for (int y = 0; y < tileMap.Height; ++y)
            {
                Tile tileData = tileMap.GetTileAt(x, y);
                GameObject tileGO = new GameObject();
                tileGO.name = "Tile_" + x + "_" + y;
                tileGO.transform.position = new Vector3(tileData.X, tileData.Y, 0);
                tileGO.AddComponent<SpriteRenderer>();
                tileGO.transform.parent = this.transform;
                tileData.RegisterTypeChangedCallback((tile) => { OnTileTypeChanged(tileData, tileGO); });
                tileData.Type = Tile.TileType.Floor;
            }
        }
    }

    void Update()
    {
    }

    void OnTileTypeChanged(Tile tileData, GameObject tileGO)
    {
        if (tileData.Type == Tile.TileType.Floor)
            tileGO.GetComponent<SpriteRenderer>().sprite = defaultTileSprite;
    }
}
