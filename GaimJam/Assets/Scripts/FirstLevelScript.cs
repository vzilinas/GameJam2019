using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstLevelScript : MonoBehaviour
{
    public GameObject SpeechBubble;
    public GameObject monsterSpawner;
    public int CurrentAction = 0;
    public bool StartNextAction = false;
    public IEnumerator[] Script;
    private GameObject progressSlider;
    private Queue<GameObject> spawners = new Queue<GameObject>();
    private Vector2[] easyCoordinates = new Vector2[] { new Vector2(8f, 4f), new Vector2(-6f, 4f), new Vector2(-6f, -3f), new Vector2(-8f, -3f), };
    private Vector2[] mediumCoordinates = new Vector2[] {
        new Vector2(7f, 3),
        new Vector2(0f, 4f),
        new Vector2(-5f, 3f),
        new Vector2(-5f, 0f),
        new Vector2(-5f, -2.5f),
        new Vector2(0f, -2.5f),
        new Vector2(7f, -2.5f),
        new Vector2(7f, 0f),
    };
    private Vector2[] hardCoordinates = new Vector2[] {
        new Vector2(6f, 2),
        new Vector2(0f, 3f),
        new Vector2(-4f, 2f),
        new Vector2(-4f, 0f),
        new Vector2(-4f, -2f),
        new Vector2(0f, -2.5f),
        new Vector2(4f, -2.5f),
        new Vector2(2.5f, 0f),
    };
    private int spawnCounter = 0;

    void Start()
    {
        progressSlider = GameObject.Find("ProgressSlider");
        Script = new IEnumerator[] {
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("Kartą seniai seniai gyveno senis ir bobutė."),
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("Augino jie mažą berniuką."),
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("Berniukas labai mylėjo savo senį ir bobutę,"),
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("beigi vienintelį savo žaisliuką meškiuką."),
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("Tačiau vieną šaltą tamsų vakarą,"),
            CreateMonster(easyCoordinates,   3),  ShowSpeechBubble("išgirdęs juoką ir linksmybes,"),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("į senio ir bobutės pirkią atklydo velnias."),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("Velnias pagrobė senio ir bobutės dūšią,"),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("tačiau berniuko neėmė,"),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("nes pasirodė per silpnas ir baikštus."),
            CreateMonster(easyCoordinates  , 5),  ShowSpeechBubble("Velnias sugalvojo pasišaipyti iš berniuko ir pasakė:"),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("jei įvykdysi 3 mano užduotis,"),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("pažadu paleisiu senį ir bobutę."),
            CreateMonster(mediumCoordinates, 5),  ShowSpeechBubble("Negalėsi naudotis niekuo,"),
            CreateMonster(easyCoordinates,   5),  ShowSpeechBubble("bet leidžiu pasiimti vieną vienintelį daiktą."),
            CreateMonster(easyCoordinates,   5),  ShowSpeechBubble("Berniukas neturėdamas ko prarasti sutiko"),
            CreateMonster(mediumCoordinates, 7),  ShowSpeechBubble("ir pasiėmė tiktai savo mylimą meškiuką."),
            CreateMonster(mediumCoordinates, 7),  ShowSpeechBubble("Berniukas labai bijojo velnio,"),
            CreateMonster(mediumCoordinates, 7),  ShowSpeechBubble("bet meškiukas staiga prabilo ir pasakė:"),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("nebijok, padėsiu tau."),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("Velnias davė užduotis vieną po kitos."),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("Pirmoji velnio užduotis buvo velniškai sukta,"),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("antroji užduotis atrodė vėl neįveikiama,"),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("o paskutinioji užduotis buvo iš visų sunkiausia."),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("Tačiau berniuko ir meškiuko tandemas"),
            CreateMonster(hardCoordinates,   7),  ShowSpeechBubble("įveikė visas pasitaikiusias kliūtis."),
            CreateMonster(hardCoordinates,   9),  ShowSpeechBubble("Velnias negalėjo patikėti ir"),
            CreateMonster(hardCoordinates,   9),  ShowSpeechBubble("neliko nieko kito kaip paleisti senį ir bobutę."),
            CreateMonster(hardCoordinates,   9),  ShowSpeechBubble("Nuo to laiko velnias daugiau"),
            CreateMonster(easyCoordinates,   9),  ShowSpeechBubble("nebegrobė žmonių ir nesikišo į jų gyvenimą,"),
            CreateMonster(easyCoordinates,   9),  ShowSpeechBubble("o berniukas, senis ir bobutė gyveno ilgai ir laimingai."),
            FinishGame()
        };
        StartNextAction = true;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (StartNextAction && Script.Length == CurrentAction)
        {
            StartNextAction = false;
        }
        else if (StartNextAction)
        {
            UpdateProgress();
            StartNextAction = false;
            StartCoroutine(Script[CurrentAction]);
            CurrentAction += 1;
        }
    }
    public void UpdateProgress()
    {
        progressSlider.GetComponent<Slider>().value = ((float)CurrentAction + 1) / (float)Script.Length;
    }
    public IEnumerator ShowSpeechBubble(string text)
    {
        GameObject speechBubble = Instantiate(SpeechBubble, new Vector3(-7, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        speechBubble.GetComponent<SpeechBubbleController>().StartAnimation(text);

        var duration = speechBubble.GetComponent<SpeechBubbleController>().EndWait + 1
                     + speechBubble.GetComponent<SpeechBubbleController>().TypingPeriod * text.Length;
        yield return new WaitForSeconds(duration);
        StartNextAction = true;
    }


    private IEnumerator CreateMonster(Vector2[] locations, int maxSpawns)
    {
        var rez = CreateMonsterSpawner(locations[spawnCounter % locations.Length], maxSpawns);
        spawnCounter++;
        return rez;
    }

    private IEnumerator CreateMonsterSpawner(Vector2 position, int maxSpawners = 1)
    {

        while (spawners.Count + 1 > maxSpawners)
        {
            var oldSpawner = spawners.Dequeue();
            Destroy(oldSpawner);
        }
        var newSpawner = Instantiate(monsterSpawner, position, Quaternion.Euler(Vector3.zero));
        spawners.Enqueue(newSpawner);
        yield return new WaitForSeconds(0f);
        StartNextAction = true;
    }

    public IEnumerator FinishGame()
    {
        SceneManager.LoadScene(3);
        yield return new WaitForSeconds(0);
    }
}
