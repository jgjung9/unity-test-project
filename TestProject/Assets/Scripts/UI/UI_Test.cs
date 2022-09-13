using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Test : UI_Base
{
    private int _btnOneCnt = 0;
    private int _btnTwoCnt = 0;

    enum Buttons
    {
        ButtonTestOne,
        ButtonTestTwo
    }

    enum Texts
    {
        MainText,
        ButtonTextOne,
        ButtonTextTwo,
    }
    
    void Start()
    {
        // UI에 있는 요소들을 찾아서 이름순서대로 묶어주는 과정
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        // UI에 있는 요소를 enum->int를 통해 인덱스처럼 파라미터로 넘겨주어 받아오는 과정
        // .onClick 부터는 받아온 컴포넌트에 이벤트를 붙인 것으로 의미가 있는 것은 아님
        Get<Button>((int)Buttons.ButtonTestOne).onClick.AddListener(ButtonOneClick);
        Get<Button>((int)Buttons.ButtonTestTwo).onClick.AddListener(ButtonTwoClick);
    }

    void Update()
    {
        
    }

    public void ButtonOneClick()
    {
        _btnOneCnt++;
        Get<TextMeshProUGUI>((int)Texts.ButtonTextOne).text = $"Button1 : {_btnOneCnt}";
        Get<TextMeshProUGUI>((int)Texts.MainText).text = $"Button1 : {_btnOneCnt} Button2 : {_btnTwoCnt}";
    }

    public void ButtonTwoClick()
    {
        _btnTwoCnt++;
        Get<TextMeshProUGUI>((int)Texts.ButtonTextTwo).text = $"Button2 : {_btnTwoCnt}";
        Get<TextMeshProUGUI>((int)Texts.MainText).text = $"Button1 : {_btnOneCnt} Button2 : {_btnTwoCnt}";
    }
}
