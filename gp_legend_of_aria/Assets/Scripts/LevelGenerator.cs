using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public float tileSize = 1.0f;
    public int minRoomSize = 5;
    public int maxRoomSize = 10;
    public int numRooms = 10;

    private List<Rect> rooms;
    private bool[,] map;

    void Start()
    {
        rooms = new List<Rect>();
        map = new bool[width, height];
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < numRooms; i++)
        {
            int roomWidth = Random.Range(minRoomSize, maxRoomSize);
            int roomHeight = Random.Range(minRoomSize, maxRoomSize);
            int roomX = Random.Range(1, width - roomWidth - 1);
            int roomZ = Random.Range(1, height - roomHeight - 1);

            Rect newRoom = new Rect(roomX, roomZ, roomWidth, roomHeight);

            bool overlap = false;
            foreach (Rect room in rooms)
            {
                if (newRoom.Overlaps(room))
                {
                    overlap = true;
                    break;
                }
            }

            if (!overlap)
            {
                rooms.Add(newRoom);
                CreateRoom(newRoom);
            }
        }

        for (int i = 1; i < rooms.Count; i++)
        {
            Rect currentRoom = rooms[i];
            Rect previousRoom = rooms[i - 1];

            Vector2 currentCenter = new Vector2(
                (int)(currentRoom.x + currentRoom.width / 2),
                (int)(currentRoom.y + currentRoom.height / 2)
            );

            Vector2 previousCenter = new Vector2(
                (int)(previousRoom.x + previousRoom.width / 2),
                (int)(previousRoom.y + previousRoom.height / 2)
            );

            if (Random.Range(0, 2) == 0)
            {
                CreateHorizontalCorridor((int)previousCenter.x, (int)currentCenter.x, (int)previousCenter.y);
                CreateVerticalCorridor((int)previousCenter.y, (int)currentCenter.y, (int)currentCenter.x);
            }
            else
            {
                CreateVerticalCorridor((int)previousCenter.y, (int)currentCenter.y, (int)previousCenter.x);
                CreateHorizontalCorridor((int)previousCenter.x, (int)currentCenter.x, (int)currentCenter.y);
            }
        }

        CreateWalls();
    }

    void CreateRoom(Rect room)
    {
        for (int x = (int)room.x; x < (int)room.xMax; x++)
        {
            for (int z = (int)room.y; z < (int)room.yMax; z++)
            {
                if (x >= 0 && x < width && z >= 0 && z < height)
                {
                    Vector3 spawnPosition = new Vector3(x * tileSize, 0, z * tileSize);
                    Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
                    map[x, z] = true;
                }
            }
        }
    }

    void CreateHorizontalCorridor(int xStart, int xEnd, int y)
    {
        for (int x = Mathf.Min(xStart, xEnd); x <= Mathf.Max(xStart, xEnd); x++)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                Vector3 spawnPosition = new Vector3(x * tileSize, 0, y * tileSize);
                if (!map[x, y])
                {
                    Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
                    map[x, y] = true;
                }
            }
        }
    }

    void CreateVerticalCorridor(int yStart, int yEnd, int x)
    {
        for (int y = Mathf.Min(yStart, yEnd); y <= Mathf.Max(yStart, yEnd); y++)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                Vector3 spawnPosition = new Vector3(x * tileSize, 0, y * tileSize);
                if (!map[x, y])
                {
                    Instantiate(floorPrefab, spawnPosition, Quaternion.identity);
                    map[x, y] = true;
                }
            }
        }
    }

    void CreateWalls()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if (map[x, z])
                {
                    // Check all 8 neighboring cells to place walls around the floor tiles
                    PlaceWallIfEmpty(x - 1, z);
                    PlaceWallIfEmpty(x + 1, z);
                    PlaceWallIfEmpty(x, z - 1);
                    PlaceWallIfEmpty(x, z + 1);
                    PlaceWallIfEmpty(x - 1, z - 1);
                    PlaceWallIfEmpty(x - 1, z + 1);
                    PlaceWallIfEmpty(x + 1, z - 1);
                    PlaceWallIfEmpty(x + 1, z + 1);
                }
            }
        }
    }

    void PlaceWallIfEmpty(int x, int z)
    {
        if (x >= 0 && x < width && z >= 0 && z < height && !map[x, z])
        {
            Vector3 wallPosition = new Vector3(x * tileSize, 0.5f, z * tileSize);
            Instantiate(wallPrefab, wallPosition, Quaternion.identity);
            map[x, z] = true; // Mark the position to prevent duplicate walls
        }
    }
}
