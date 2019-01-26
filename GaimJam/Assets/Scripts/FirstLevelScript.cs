using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelScript : MonoBehaviour
{
    public GameObject SpeechBubble;
    public int CurrentAction = 0;
    public bool StartNextAction = false;
    public IEnumerator[] Script;
    // Start is called before the first frame update
    void Start()
    {
        Script = new IEnumerator[] {
            ShowSpeechBubble(
                " Kartą seniai seniai gyveno senis ir bobutė. \n" + 
                " Augino jie mažą berniuką. \n" +
                " Berniukas labai mylėjo savo senį ir bobutę, \n" +
                " beigi vienintelį savo žaisliuką meškiuką. \n" +
                " Tačiau vieną šaltą tamsų vakarą, \n" + 
                " išgirdęs juoką ir linksmybes, \n" +
                " į senio ir bobutės pirkią atklydo velnias. \n" +
                " Velnias pagrobė senio ir bobutės dūšią, \n" +
                " tačiau berniuko neėmė, \n" +
                " nes pasirodė per silpnas ir baikštus. \n" +
                " Velnias sugalvojo pasišaipyti iš berniuko ir pasakė: \n" +
                " jei įvykdysi 3 mano užduotis, \n" +
                " pažadu paleisiu senį ir bobutę. \n" +
                " Negalėsi naudotis niekuo, \n" +
                " bet leidžiu pasiimti vieną vienintelį daiktą. \n" +
                " Berniukas neturėdamas ko prarasti sutiko \n" +
                " ir pasiėmė tiktai savo mylimą meškiuką. \n" +
                " Berniukas labai bijojo velnio, \n" +
                " bet meškiukas staiga prabilo ir pasakė: \n" +
                " nebijok, padėsiu tau. \n" +
                " Velnias davė užduotis vieną po kitos. \n" +
                " Pirmoji velnio užduotis buvo velniškai sukta, \n" +
                " antroji užduotis atrodė vėl neįveikiama, \n" +
                " o paskutinioji užduotis buvo iš visų sunkiausia. \n" +
                " Tačiau berniuko ir meškiuko tandemas \n" +
                " įveikė visas pasitaikiusias kliūtis. \n" +
                " Velnias negalėjo patikėti ir \n" +
                " neliko nieko kito kaip paleisti senį ir bobutę. \n" +
                " Nuo to laiko velnias daugiau \n" +
                " nebegrobė žmonių ir nesikišo į jų gyvenimą, \n" +
                " o berniukas, senis ir bobutė gyveno ilgai ir laimingai. \n"
                ),
            LogText(2f, "Log this text"),       // gal reikia padaryti, kad priimtų veikėjo klasę kas kalba ir atvaizuotų profilį beigi vardą
            LogText(3f, "Log this other text")  // ir išviso, gal ne laikas, o paspaudus mygtuką turėtų pereiti į kitą dialogą
        };
        StartNextAction = true;
        //MonoBehaviourExtensions.Invoke(this, GetMetod, 0);
    }
    public IEnumerator LogText(float delay, string whatToLog)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(whatToLog);
        StartNextAction = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(StartNextAction && Script.Length == CurrentAction)
        {
            StartNextAction = false;
        }
        else if(StartNextAction == true)
        {
            StartNextAction = false;
            StartCoroutine(Script[CurrentAction]);
            CurrentAction += 1;
        }
    }

    public IEnumerator ShowSpeechBubble(string text)
    {
        yield return new WaitForSeconds(0);
        GameObject speechBubble = Instantiate(SpeechBubble, new Vector3(-7, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        speechBubble.GetComponent<SpeechBubbleController>().StartAnimation(text);
    }
}
