using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUi : MonoBehaviour
{
    [Header("UI 组件")]
    public Image characterImage; // 显示人物图片的 UI 组件
    public TextMeshProUGUI characterText; // 显示人物介绍的 UI 组件

    [Header("人物数据")]
    public Sprite[] characterSprites; // 人物图片数组
    public string[] characterDescriptions; // 人物介绍文本数组

    private int currentIndex = 0; // 当前索引

    void Start()
    {
        UpdateUI(); // 初始化 UI
    }

    // 更新 UI 显示
    void UpdateUI()
    {
        if (characterSprites.Length > 0 && characterDescriptions.Length > 0)
        {
            characterImage.sprite = characterSprites[currentIndex];
            characterText.text = characterDescriptions[currentIndex];
        }
    }

    // 切换到下一个人物
    public void NextCharacter()
    {
        if (characterSprites.Length == 0 || characterDescriptions.Length == 0) return;

        currentIndex++;
        if (currentIndex >= characterSprites.Length) // 循环到第一个
        {
            currentIndex = 0;
        }

        UpdateUI();
    }

    // 切换到上一个人物
    public void PreviousCharacter()
    {
        if (characterSprites.Length == 0 || characterDescriptions.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0) // 循环到最后一个
        {
            currentIndex = characterSprites.Length - 1;
        }

        UpdateUI();
    }
}
