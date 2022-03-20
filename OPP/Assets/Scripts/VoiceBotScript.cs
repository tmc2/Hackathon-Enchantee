using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoiceBotScript : MonoBehaviour
{
    // Chat panel
    [SerializeField]
    private GameObject panel;


    // Bot text prefab
    [SerializeField]
    private GameObject bot_text_prefab;

    // User text prefab
    [SerializeField]
    private GameObject user_text_prefab;

    // User options
    [SerializeField]
    private TMP_Text user_options_text;

    private List<string> bot_sentences = new List<string>
            { "Bonjour Maria !\nComment vas-tu ?",
              "Super ! Tu vas bien !\nTu connais Paris ?",
              "Répétez s'il vous plait"
    };

    private List<string> options_list = new List<string>
           { "<b>A:</b> Salut! Je vais bien.\n<b>Ou</b>\n<b>B:</b> Salut! Pas très bien",
             "<b>A:</b> Oui, je connais Paris.\n<b>Ou</b>\n<b>B:</b> Non, je ne connais pas Paris."

    };

    private int microphone_counter = 0;

    public void next()
    {
        if(microphone_counter == 0)
        {
            // Create a new prefab object and add the correct text for it
            GameObject text_panel = Instantiate(user_text_prefab);
            var text_panel_text = text_panel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
            text_panel_text.text = "Salut! Je vais bien.";

            // Add it to the scrolling panel
            text_panel.transform.SetParent(panel.transform, false);

            // Add the next bot sentence
            GameObject bot_text_panel = Instantiate(bot_text_prefab);
            var bot_text_panel_text = bot_text_panel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
            bot_text_panel_text.text = bot_sentences[microphone_counter + 1];

            // Add it to the scrolling panel
            bot_text_panel.transform.SetParent(panel.transform, false);

            // change the user options
            user_options_text.text = options_list[microphone_counter + 1];


            microphone_counter++;

        } else if (microphone_counter == 1) // we are currently simulating an misspelling by the user
        {
            // Add the next bot sentence
            GameObject bot_text_panel = Instantiate(bot_text_prefab);
            var bot_text_panel_text = bot_text_panel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
            bot_text_panel_text.text = bot_sentences[microphone_counter + 1];

            // Add it to the scrolling panel
            bot_text_panel.transform.SetParent(panel.transform, false);

            microphone_counter++;
        }
    }
}
