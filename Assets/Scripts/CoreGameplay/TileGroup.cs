using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour
{
    public int gridHeight { get; private set; } = 4;
    public int gridWidth { get; private set; } = 5;

    [SerializeField]
    private float gridSpace = 3f;
    [SerializeField]
    GameObject tilePrefabs;
    private TileObject[,] tileObjects;

    [SerializeField]
    Sprite[] tiles;

    [SerializeField]
    private List<Sprite> gameTiles = new List<Sprite>();

    [SerializeField]
    private List<GameObject> tileSprites = new List<GameObject>();

    private bool firstChoice;
    private bool secondChoice;

    private int countChoice;
    private int countCorrectChoice;
    private int gameChoice;

    private int firstChoiceIndex;
    private int secondChoiceIndex;

    private string firstChoiceTiles;
    private string secondChoiceTiles;

    [SerializeField]
    Transform tileParent;

    [SerializeField]
    InputRaycast clicked;

    private string nameTile;

    private void Awake()
    {
        tiles = Resources.LoadAll<Sprite>("Sprites/Food");
    }

    private void OnEnable()
    {
        CreateGrid();
        ChangeNames();
        GetTiles();
        AddGameTiles();
        Randomize(gameTiles);
        clicked.OnClicked += OnClicked;
    }
    private void OnDisable()
    {
        clicked.OnClicked -= OnClicked;
    }
    private void CreateGrid()
    {
        tileObjects = new TileObject[gridHeight, gridWidth];
        for (int i=0; i<gridHeight; i++)
        {

            for (int j=0; j<gridWidth; j++)
            {
                tileObjects[i, j] = Instantiate(tilePrefabs, new Vector3(i * gridSpace, j * gridSpace, 0), Quaternion.identity).GetComponent<TileObject>();
                tileObjects[i, j].GetComponent<TileObject>().SetPosition(i, j);
                tileObjects[i, j].transform.parent = transform;
            }
        }
    }
    private void ChangeNames()
    {
        int child = tileParent.childCount;
        for (int i=0; i<child; i++)
        {
            tileParent.GetChild(i).gameObject.name = "" + i;
        }
        
    }
    private void AddGameTiles()
    {
        int looper = tileSprites.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gameTiles.Add(tiles[index]);

            index++;
        }
    }
    private void GetTiles()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Tile");

        for (int i = 0; i < objects.Length; i++)
        {
            tileSprites.Add(objects[i].gameObject);
            tileSprites[i].GetComponent<SpriteRenderer>().sprite = tiles[i];
        }
    }
    private void OnClicked()
    {
        Debug.Log("JALAN");
        ChooseTile();
    }
    private void ChooseTile()
    {
        int i;
        if(!firstChoice)
        {
            firstChoice = true;
            if(int.TryParse(nameTile, out i))
            {
                firstChoiceIndex = i;
            }
            firstChoiceTiles = gameTiles[firstChoiceIndex].name;
            tileSprites[firstChoiceIndex].GetComponent<SpriteRenderer>().sprite = gameTiles[firstChoiceIndex];
        }
        else if (!secondChoice)
        {
            secondChoice = true;
            if (int.TryParse(nameTile, out i))
            {
                secondChoiceIndex = i;
            }
            secondChoiceTiles = gameTiles[secondChoiceIndex].name;
            tileSprites[secondChoiceIndex].GetComponent<SpriteRenderer>().sprite = gameTiles[secondChoiceIndex];

            StartCoroutine(CheckMatchTiles());
        }
    }
    IEnumerator CheckMatchTiles()
    {
        yield return new WaitForSeconds(.1f);
        if (firstChoiceTiles == secondChoiceTiles)
        {
            Debug.Log("COCOK");
            Destroy(tileSprites[firstChoiceIndex].gameObject);
            Destroy(tileSprites[secondChoiceIndex].gameObject);
        }
        else
        {
            Debug.Log("ENGGAK");
        }
    }
    public void SetName(string n)
    {
        nameTile = n;
    }
    private void Randomize(List<Sprite> list)
    {
        for (int x=0; x<list.Count; x++)
        {
            Sprite temp = list[x];
            int randomIndex = Random.Range(x, list.Count);
            list[x] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
