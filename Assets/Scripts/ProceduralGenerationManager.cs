using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGenerationManager : MonoBehaviour
{
    [SerializeField] private MapTileset mainTileset;
    [SerializeField] private MapTile latestGeneratedTile;
    [SerializeField] private float minGenerationRange, currentOffset;
    [SerializeField] private Vector3 tileWorldSpaceConversion;
    [SerializeField] private Vector3 startPosition;

    [SerializeField] private int treeGridIncrement;
    [SerializeField] private int regionSize = 100;
    [SerializeField] private List<Vector2> regionList = new List<Vector2>();



    void Start()
    {
        if (latestGeneratedTile.tile == null)
        {
            GenerateNewTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(latestGeneratedTile.transform.position, Player.instance.transform.position);
        // Debug.Log(dist);
        if (dist < minGenerationRange)
        {
            GenerateNewTile();
        }
        Debug.Log("DIST: " + dist);
    }

    void GenerateNewTile()
    {
        MapTile newTile = ChooseTile();

        GameObject newTileObj;
        Vector3 newPosition;
        Quaternion newRotation;

        if (latestGeneratedTile.tile != null)
        {
            // Main tile placement and rotation code
            Vector3 newLocalPosition = latestGeneratedTile.outPosition - newTile.inPosition;
            newPosition = latestGeneratedTile.transform.TransformPoint(newLocalPosition);
            newRotation = Quaternion.Euler(latestGeneratedTile.transform.rotation.eulerAngles - latestGeneratedTile.eulerOffsetOut);
            currentOffset += latestGeneratedTile.eulerOffsetOut.y;
        }
        else
        {
            // Initial tile settings
            newPosition = startPosition;
            newRotation = transform.rotation;
        }

        newTileObj = Instantiate(newTile.tile, newPosition, newRotation);
        latestGeneratedTile = newTile;
        latestGeneratedTile.tile = newTileObj;
    }
    MapTile ChooseTile() {

        List<MapTile> selectableTiles = new List<MapTile>{
            mainTileset.straight,
            mainTileset.left90,
            mainTileset.right90
        };

        if(currentOffset <= -90){selectableTiles.Remove(mainTileset.right90);}
        else if(currentOffset >= 90){selectableTiles.Remove(mainTileset.left90);}
        return selectableTiles[UnityEngine.Random.Range(0, selectableTiles.Count)];
    }

    // Vector3 WorldToTileSpace(Vector3 worldPos)
    // {
    //     return new Vector3(
    //         worldPos.x / tileWorldSpaceConversion.x,
    //         worldPos.y / tileWorldSpaceConversion.y,
    //         worldPos.z / tileWorldSpaceConversion.z
    //     );
    // }

    // Vector3 TileToWorldSpace(Vector3 tilePos)
    // {
    //     return new Vector3(
    //         tilePos.x * tileWorldSpaceConversion.x,
    //         tilePos.y * tileWorldSpaceConversion.y,
    //         tilePos.z * tileWorldSpaceConversion.z
    //     );
    // }
}

[Serializable]
public struct MapTileset
{
    public MapTile straight, left90, right90;
}

[Serializable]
public struct MapTile {
    public GameObject tile;
    public Transform transform {get { return tile.transform; }}
    public Vector3 inPosition, outPosition;
    public Vector3 eulerOffsetOut;

}
