using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

public class LanguageChange_VS : MonoBehaviour
{
    [SerializeField]
    string fileName;

    Dropdown languageDropdown;
    [SerializeField]
    Text settingsText, currentlanguageText, language, backButtonText;


    // Start is called before the first frame update
    void Start()
    {
        languageDropdown = GetComponentInChildren<Dropdown>(true);

        if(languageDropdown == null)
        {
            Debug.Log("Dropdown is null");

        }
        else
        {
            ChangeLanguagesNames();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLanguagesNames()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(Application.dataPath + "/" + fileName);
        XmlElement rootElement = xmlDocument.DocumentElement;

        XmlNodeList languages = rootElement.ChildNodes;

        languageDropdown.options.Clear();
        for(int i = 0; i < languages.Count; i++)
        {
            languageDropdown.options.Add(new Dropdown.OptionData(languages[i].Name));
        }
    }

    public void ChangeTheLanguage(int index)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(Application.dataPath + "/" + fileName);
        XmlElement rootElement = xmlDocument.DocumentElement;
        XmlNodeList languages = rootElement.ChildNodes;

        XmlNodeList currentLanguage = languages[index].ChildNodes;
        
        for(int i = 0; i < currentLanguage.Count; i++)
        {
            switch (currentLanguage[i].Name)
            {
                case "Settings":
                    settingsText.text = currentLanguage[i].InnerText;
                    break;
                case "Language":
                    language.text = currentLanguage[i].InnerText;
                    break;
                case "CurrentLanguage":
                    currentlanguageText.text = currentLanguage[i].InnerText;
                    break;
                case "Back":
                    backButtonText.text = currentLanguage[i].InnerText;
                    break;
            }
        }

    }
}
