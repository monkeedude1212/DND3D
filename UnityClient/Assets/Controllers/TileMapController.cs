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
                Tile tileData = tileMap.GetTileAt(x, y);
                GameObject tileGO = new GameObject();
                tileGO.name = "Tile_" + x + "_" + y;
                tileGO.transform.position = new Vector3(tileData.X, tileData.Y, 0);
                tileGO.AddComponent<SpriteRenderer>();
                tileGO.transform.parent = this.transform;
                tileData.RegisterTypeChangedCallback((tile) => { OnTileTypeChanged(tileData, tileGO); });
                tileData.RegisterSelectedCallback((tile) => { OnTileSelected(tileData, tileGO); });
                tileData.RegisterDeselectedCallback((tile) => { OnTileDeselected(tileData, tileGO); });
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

    void OnTileSelected(Tile tileData, GameObject tileGO)
    {
        tileGO.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
    }

    void OnTileDeselected(Tile tileData, GameObject tileGO)
    {
        tileGO.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
