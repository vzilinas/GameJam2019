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
    private Vector2[] mediumCoordinates = new Vector2[] { new Vector2(7f, 3), new Vector2(0f, 4f), new Vector2(-5f, 3f), new Vector2(-5f, -2f), new Vector2(-7f, -2.5f) };
    private int spawnCounter = 0;

    void Start()
    {
        progressSlider = GameObject.Find("ProgressSlider");
        Script = new IEnumerator[] {
            CreateEasyMonster(),    ShowSpeechBubble("Kartą seniai seniai gyveno senis ir bobutė."),
            CreateEasyMonster(),    ShowSpeechBubble("Augino jie mažą berniuką."),
            CreateEasyMonster(),    ShowSpeechBubble("Berniukas labai mylėjo savo senį ir bobutę,"),
            CreateEasyMonster(),    ShowSpeechBubble("beigi vienintelį savo žaisliuką meškiuką."),
            CreateEasyMonster(),    ShowSpeechBubble("Tačiau vieną šaltą tamsų vakarą,"),
            CreateEasyMonster(),    ShowSpeechBubble("išgirdęs juoką ir linksmybes,"),
            CreateEasyMonster(),    ShowSpeechBubble("į senio ir bobutės pirkią atklydo velnias."),
            CreateMediumMonster(),  ShowSpeechBubble("Velnias pagrobė senio ir bobutės dūšią,"), 
            CreateMediumMonster(),  ShowSpeechBubble("tačiau berniuko neėmė,"),
            CreateMediumMonster(),  ShowSpeechBubble("nes pasirodė per silpnas ir baikštus."),
            CreateMediumMonster(),  ShowSpeechBubble("Velnias sugalvojo pasišaipyti iš berniuko ir pasakė:"),
            CreateMediumMonster(),  ShowSpeechBubble("jei įvykdysi 3 mano užduotis,"),
            CreateMediumMonster(),  ShowSpeechBubble("pažadu paleisiu senį ir bobutę."),
            CreateMediumMonster(),  ShowSpeechBubble("Negalėsi naudotis niekuo,"),
            CreateMediumMonster(),  ShowSpeechBubble("bet leidžiu pasiimti vieną vienintelį daiktą."),
            CreateMediumMonster(),  ShowSpeechBubble("Berniukas neturėdamas ko prarasti sutiko"),
            CreateMediumMonster(),  ShowSpeechBubble("ir pasiėmė tiktai savo mylimą meškiuką."),
            ShowSpeechBubble("Berniukas labai bijojo velnio,"),
            ShowSpeechBubble("bet meškiukas staiga prabilo ir pasakė:"),
            ShowSpeechBubble("nebijok, padėsiu tau."),
            ShowSpeechBubble("Velnias davė užduotis vieną po kitos."),
            ShowSpeechBubble("Pirmoji velnio užduotis buvo velniškai sukta,"),
            ShowSpeechBubble("antroji užduotis atrodė vėl neįveikiama,"),
            ShowSpeechBubble("o paskutinioji užduotis buvo iš visų sunkiausia."),
            ShowSpeechBubble("Tačiau berniuko ir meškiuko tandemas"),
            ShowSpeechBubble("įveikė visas pasitaikiusias kliūtis."),
            ShowSpeechBubble("Velnias negalėjo patikėti ir"),
            ShowSpeechBubble("neliko nieko kito kaip paleisti senį ir bobutę."),
            ShowSpeechBubble("Nuo to laiko velnias daugiau"),
            ShowSpeechBubble("nebegrobė žmonių ir nesikišo į jų gyvenimą,"),
            ShowSpeechBubble("o berniukas, senis ir bobutė gyveno ilgai ir laimingai."),
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

        
    private IEnumerator CreateEasyMonster()
    {
        var rez = CreateMonsterSpawner(easyCoordinates[spawnCounter % easyCoordinates.Length], 3); 
        spawnCounter++;
        return rez;
    }

    private IEnumerator CreateMediumMonster()
    {
        var rez = CreateMonsterSpawner(mediumCoordinates[spawnCounter % easyCoordinates.Length], 5);
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
