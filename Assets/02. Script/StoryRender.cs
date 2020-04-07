using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryRender : MonoBehaviour
{
    //페이지 데이터베이스->에디터에서 받아올수있게
    [System.Serializable]
    public class StoryProperty
    {
        public Sprite sprite;
        public string story;//스토리 텍스트
    }

    //페이지 넘기기 버튼 <-, ->
    public Button previousPageButton, nextPageButton;
    // 스토리 이미지
    public Image storyImg;
    // 스토리 텍스트
    public TextMeshProUGUI storyText;

    public List<StoryProperty> storyData;

    //현재 몇페이지?
    int currentPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //이전, 다음 페이지가 존재하면 버튼에 불들어오게
    void UpdateUI()
    {
        previousPageButton.interactable = currentPage > 0; //이전 페이지 존재
        nextPageButton.interactable = currentPage < storyData.Count - 1; //다음페이지 존재

        UpdateContent();
    }

    //현재 페이지에 맞는 content 띄움
    void UpdateContent()
    {
        storyImg.sprite = storyData[currentPage].sprite;
        StopAllCoroutines();
        StartCoroutine(AppearTextOneByOne(0.1f));//0.1초에 한글자씩 띄움
    }

    //텍스트 시간차 두고 띄움
    IEnumerator AppearTextOneByOne(float interval)
    {
        int index = 1;
        string story = storyData[currentPage].story;

        while(index <= story.Length)
        {
            storyText.text = story.Substring(0,index);//전체 스트링 index추출
            yield return new WaitForSeconds(interval);//IEnumerator면 yield 꼭 붙어야함(멈췄다가 시간이되면 다시 진행)
            index++;

        }
    }

    //<- 버튼 클릭시 동작
    public void OnClickPrevBtn()
    {
        Debug.Log("click prev button");

        currentPage--;

        UpdateUI();
    }

    //-> 버튼 클릭시 동작
    public void OnClickNextBtn()
    {
        Debug.Log("click next button");

        currentPage++;

        UpdateUI();
    }

}
