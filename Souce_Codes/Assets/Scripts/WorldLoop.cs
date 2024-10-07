using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoop : MonoBehaviour
{
    Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0, 0);
    [SerializeField] Vector2Int playerTilePosition;
    Vector2Int onTileGridPLayerPosition;

    [SerializeField] float tileSize = 16f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;
    [SerializeField] int fieldOfVisionHeight = 2;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake() 
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount,terrainTileVerticalCount];
    }
    private void Start() 
    {
        UpdateTileOnScreen();
        playerTransform = GameManager.Instance.playerTransform;
    }
    private void Update() 
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;


        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;
            
            onTileGridPLayerPosition.x = CalculatePositionOnAxis(onTileGridPLayerPosition.x,true);
            onTileGridPLayerPosition.y = CalculatePositionOnAxis(onTileGridPLayerPosition.y,false);

            UpdateTileOnScreen();
        }

    }
    private void UpdateTileOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth/2); pov_x < fieldOfVisionWidth/2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight/2); pov_y < fieldOfVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x,true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y,false);

                GameObject tile = terrainTiles[tileToUpdate_x,tileToUpdate_y];
                Vector3 newPostion = CalculateTilePosition(playerTilePosition.x + pov_x,playerTilePosition.y + pov_y);
                
                if (newPostion != tile.transform.position)
                {
                    tile.transform.position = newPostion;
                    terrainTiles[tileToUpdate_x, tileToUpdate_y].GetComponent<TerrainTile>().Spawn();
                }

            }
        } 

    }

    private Vector2 CalculateTilePosition(int x, int y)
    {
        return new Vector2(x*tileSize, y*tileSize);
    }

    private int CalculatePositionOnAxis(float currentValue,bool horizontal)
    {
        if (horizontal)
        {
            if(currentValue >= 0)
                currentValue = currentValue % terrainTileHorizontalCount;
            else
            {
                currentValue +=1;
                currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if(currentValue >= 0)
                currentValue = currentValue % terrainTileVerticalCount;
            else
            {
                currentValue +=1;
                currentValue = terrainTileVerticalCount -1 + currentValue % terrainTileVerticalCount;
            }
                
        }
        return (int)currentValue;
        
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x,tilePosition.y] = tileGameObject;
    }

}
