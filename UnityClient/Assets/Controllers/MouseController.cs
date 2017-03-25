using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour 
{
    public new Camera camera = null;
    public GameObject cursor = null;
    private Vector3 lastPos = new Vector3(0,0,0);
    private const int LMB = 0, RMB = 1, MMB = 2;
    private Tile clickedTile = null;

	void Start () 
    {
        lastPos = camera.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void Update () 
    {
        Vector3 worldPos = camera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        Tile tile = getTileAt(worldPos);

        // Move mouse cursor
        if (cursor != null)
            cursor.transform.position = worldPos;

        // Move camera
        if (Input.GetMouseButton(RMB) || Input.GetMouseButton(MMB))
        {
            camera.transform.Translate(lastPos - worldPos);
        }

        // Zoom
        camera.orthographicSize -= camera.orthographicSize * Input.GetAxis("Mouse ScrollWheel");
        
        // Select Tiles
        if (Input.GetMouseButtonDown(LMB))
        {
                clickedTile = tile;
        }
        else if (Input.GetMouseButtonUp(LMB))
        {
            if (tile != null && tile == clickedTile)
            {
                if (tile.Selected)
                {
                    tile.Selected = false;
                }
                else
                {
                    tile.Selected = true;
                }
                clickedTile = null;
            }
        }

        lastPos = camera.ScreenToWorldPoint(Input.mousePosition);
        lastPos.z = 0;
	}

    Tile getTileAt(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x);
        int y = Mathf.FloorToInt(position.y);
        return TileMapController.Instance.tileMap.GetTileAt(x, y);
    }
}
