using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapController : MonoBehaviour
{
    static TileMapController instance = null;
    public static TileMapController Instance
    {
        get
        {
            return instance;
        }

        protected set
        {
            if (instance != null)
                Debug.LogError("There can only be one instance of TileMapController");
            instance = value;
        }
    }

    public Sprite defaultTileSprite;
    public TileMap tileMap;

    void Start()
    {
        Instance = this;
        tileMap = new TileMap();
        for (int x = 0; x < tileMap.Width; ++x)
        {
            for (int y = 0; y < tileMap.Height; ++y)
            {
                Tile tileData = tileMap.getTileAt(x, y);
                GameObject tileGO = new GameObject();
                tileGO.name = "Tile_" + x + "_" + y;
                tileGO.transform.position = new Vector3(tileData.X, tileData.Y, 0);
                tileGO.AddComponent<SpriteRenderer>();
                tileGO.transform.parent = this.transform;
                tileData.registerTypeChangedCallback((tile) => { onTileTypeChanged(tileData, tileGO); });
                tileData.registerSelectedCallback((tile) => { onTileSelected(tileData, tileGO); });
                tileData.registerDeselectedCallback((tile) => { onTileDeselected(tileData, tileGO); });
                tileData.Type = Tile.TileType.Floor;
            }
        }
    }

    void Update()
    {
    }

    void onTileTypeChanged(Tile tileData, GameObject tileGO)
    {
        if (tileData.Type == Tile.TileType.Floor)
            tileGO.GetComponent<SpriteRenderer>().sprite = defaultTileSprite;
    }

    void onTileSelected(Tile tileData, GameObject tileGO)
    {
        tileGO.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
    }

    void onTileDeselected(Tile tileData, GameObject tileGO)
    {
        tileGO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
