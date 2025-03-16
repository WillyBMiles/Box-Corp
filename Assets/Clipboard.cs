using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour
{
    public static Clipboard instance;
    public GameObject parent;

    public GridLayoutGroup grid;

    public Image imagePrefab;

    public List<Sprite> acceptSprites;
    public List<Sprite> sizeSprites;
    public List<Sprite> weightSprites;
    public List<Sprite> magnetSprites;

    public bool PausedProduction;

    public Text bonusText;

    [Space]
    public Image pauseIndicator;
    public Sprite go;
    public Sprite gont;

    [Space]
    public List<GameObject> tutorials = new();
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            parent.SetActive(!parent.activeInHierarchy);
        }
        bonusText.text = "$" + Mathf.Round(AvailableObjects.instance.multiplier * 10f) / 10f;

        pauseIndicator.sprite = PausedProduction ? gont : go;
    }

    public void Recalculate()
    {
        foreach (Transform t in grid.transform)
        {
            if (t.GetComponent<Text>() == null)
                GameObject.Destroy(t.gameObject);
        }

        foreach (BoxContents bc in AvailableObjects.instance.currentContents)
        {
            Instantiate(imagePrefab, grid.transform).sprite = bc.sprite;
            Instantiate(imagePrefab, grid.transform).sprite = bc.accepted ? acceptSprites[0] : acceptSprites[1];
            Instantiate(imagePrefab, grid.transform).sprite = sizeSprites[(int)bc.size];
            Instantiate(imagePrefab, grid.transform).sprite = weightSprites[(int)bc.weight];
            Instantiate(imagePrefab, grid.transform).sprite = bc.magnetic ? magnetSprites[0] : magnetSprites[1];
        }
        float size = Mathf.Lerp(60, 25, ((grid.transform.childCount - 5f) / (16f * 10f)));
        grid.cellSize = new Vector2(size, size);
    }

    public void PauseProduction()
    {
        PausedProduction = !PausedProduction;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void DestroyTutorial()
    {
        foreach (GameObject go in tutorials)
        {
            GameObject.Destroy(go);
        }
    }
}
