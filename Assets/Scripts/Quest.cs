using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quest : MonoBehaviour
{
    //public Sprite[] quest;
    //public string[] questText;
    //public Sprite currentImage;
    //public string currenText;
    //public Quest[] quest;
    //int index = 0;
    [System.Serializable]
    public class QuestDataProperty
    {
        public Sprite sprite;
        public string description;
    }
    public Button previousPageButton, nextPageButton;
    public Image questImg;
    public TextMeshProUGUI descriptionTxt;

    public List<QuestDataProperty> questData;
    int currentPage;

    
    // Start is called before the first frame update
    void Start()
    {
        //quest[index] = quest[0];
        //questText[index] = questText[0];
        //questImg.sprite = quest[0].sprite;
        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        previousPageButton.interactable = currentPage > 0;
        nextPageButton.interactable = currentPage < questData.Count - 1;

        UpdateContent();
    }
    void UpdateContent()
    {
        questImg.sprite = questData[currentPage].sprite;
        //descriptionTxt.text = questDate[currentPage].description;

        StopAllCoroutines();
        StartCoroutine(AppearTextOneByOne(0.1f));
    }

    IEnumerator AppearTextOneByOne(float interval)
    {
        int index = 1;
        string description = questData[currentPage].description;

        while(index <= description.Length)
        {
            descriptionTxt.text = description.Substring(0, index);
            yield return new WaitForSeconds(interval);
            index++;
        }
    }
    public void OnClickPrevButton()
    {
        currentPage--;
        UpdateUI();
    }
    public void OnClickNextButton()
    {
        currentPage++;
        UpdateUI();
    }
}
