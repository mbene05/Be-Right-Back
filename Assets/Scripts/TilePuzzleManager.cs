using UnityEngine;
using System.Collections;

public class TilePuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    public Camera _camera;
    public float disNum = 2f;
    [SerializeField] private TileScript[] tiles;
    private int emptySpaceIndex = 8;
    public bool inrightPlace;
public int number;
public Vector2 targetPosition;
    public int correctTiles;
    public GameObject skipButton;

    public GameObject chef;

    bool done = false;

    public GameObject tileTrigger;

    public bool move = false;
    void Start()
    {
        
        skipButton.SetActive(false);
       Shuffle();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && done == false)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit)
            {
                if (Vector2.Distance(emptySpace.position,hit.transform.position) < disNum)
                {
                    if (move == false)
                    {
                        StartCoroutine(ShowSkipAfterDelay());
                        move = true;
                    }
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }

        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if(a.inrightPlace)
                    correctTiles++;
            }
        }
        
        if (correctTiles == 8 && done == false)
        {
                ChefManager selectedChef = chef.GetComponent<ChefManager>();
                selectedChef.logsCollected++;
                done = true;
                tileTrigger.SetActive(true);

        }

    }

 public void SkipDialogue()
{
    if (done) return;

    // Move every tile to its correct position
    foreach (TileScript tile in tiles)
    {
        if (tile != null)
        {
            tile.targetPosition = tile.correctPosition;
        }
    }

    // Move empty space back to correct spot (last index)
    emptySpace.position = tiles[8] == null 
        ? emptySpace.position 
        : tiles[8].correctPosition;

    emptySpaceIndex = 8;

    // Mark puzzle complete
    ChefManager selectedChef = chef.GetComponent<ChefManager>();
    selectedChef.logsCollected++;

    tileTrigger.SetActive(true);
    done = true;

    skipButton.SetActive(false);
}

    IEnumerator ShowSkipAfterDelay()
    {
        yield return new WaitForSeconds(100f); 
        skipButton.SetActive(true);
    }



    public void Shuffle()
    {
        if (emptySpaceIndex != 8)
        {
            var tileOn15LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn15LastPos;
             tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;
           
        }
        int invertion;
        do
        {
            for(int i = 0; i <= 7; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0,7);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }

            invertion = GetInversions();

        } while(invertion%2 != 0);
    }

    public int findIndex(TileScript ts)
    {
        for (int i = 0; i < tiles.Length; i ++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum+= thisTileInvertion;
        }
        return inversionsSum;
    }
}