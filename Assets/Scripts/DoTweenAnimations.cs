using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DoTweenAnimations : MonoBehaviour
{
    public RectTransform aboutPage; // Assign the UI Panel (RectTransform) in Inspector

    public RectTransform resumePage;

    public GameObject controlPage;
    public GameObject levelPage;

    public CanvasGroup levelPageCanvasGroup;

    public CanvasGroup aboutPageCanvasGroup;
    public CanvasGroup resumePageCanvasGroup;
    public CanvasGroup controlPagecanvasGroup;

    private Vector2 aboutHiddenPosition = new Vector2(-1850, 0);
    private Vector2 aboutvisiblePosition = new Vector2(0, 0);
    private Vector2 resumeHiddenPosition = new Vector2(1850, 0);
    private Vector2 resumevisiblePosition = new Vector2(0, 0);



    void Start()
    {
        aboutPage.anchoredPosition = aboutHiddenPosition; // Start Hidden
        resumePage.anchoredPosition = resumeHiddenPosition;
        aboutPageCanvasGroup.alpha = 0;
        resumePageCanvasGroup.alpha = 0;
        // Get or Add CanvasGroup component
        controlPagecanvasGroup = controlPage.GetComponent<CanvasGroup>();
        if (controlPagecanvasGroup == null)
            controlPagecanvasGroup = controlPage.AddComponent<CanvasGroup>();

        // Initially, make it invisible
        controlPagecanvasGroup.alpha = 0;
        controlPage.SetActive(false);
        levelPageCanvasGroup = levelPage.GetComponent<CanvasGroup>();
        if (levelPageCanvasGroup == null)
            levelPageCanvasGroup = levelPage.AddComponent<CanvasGroup>();

        // Initially, make it invisible
        levelPageCanvasGroup.alpha = 0;
        levelPage.SetActive(false);
    }

    public void AboutPageEnableTransition()
    {
        aboutPageCanvasGroup.DOFade(1, 0.5f);
        aboutPage.DOAnchorPos(aboutvisiblePosition, 0.5f).SetEase(Ease.OutExpo); // Slide in smoothly
    }

    public void AboutPageDisableTransition()
    {
        aboutPageCanvasGroup.DOFade(0, 0.3f);
        aboutPage.DOAnchorPos(aboutHiddenPosition, 0.5f).SetEase(Ease.InExpo); // Slide out smoothly
    }

    public void ResumePageEnableTransition()
    {
        resumePageCanvasGroup.DOFade(1, 0.5f);
        resumePage.DOAnchorPos(resumevisiblePosition, 0.5f).SetEase(Ease.OutExpo); // Slide in smoothly
    }
    public void ResumePageDisableTransition()
    {
        resumePageCanvasGroup.DOFade(0, 0.3f);
        resumePage.DOAnchorPos(resumeHiddenPosition, 0.5f).SetEase(Ease.InExpo); // Slide out smoothly
    }
    public void ShowControlPage()
    {
        controlPage.SetActive(true); // Enable GameObject
        controlPagecanvasGroup.alpha = 0; // Ensure starting alpha is 0
        controlPagecanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutSine); // Smooth fade-in effect
    }

    public void HideControlPage()
    {
        controlPagecanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            controlPage.SetActive(false); // Disable after fade-out
        });
    }
     public void ShowLevelPage()
    {
        levelPage.SetActive(true); // Enable GameObject
        levelPageCanvasGroup.alpha = 0; // Ensure starting alpha is 0
        levelPageCanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutSine); // Smooth fade-in effect
    }

    public void HideLevelPage()
    {
        levelPageCanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.InSine).OnComplete(() =>
        {
            levelPage.SetActive(false); // Disable after fade-out
        });
    }
}
