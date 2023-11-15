using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeUIController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private float dragThreshold;

    [SerializeField]
    private DemandsController[] demands;

    [SerializeField]
    private GameObject body, demandsContainer, footer, iconPrefab;

    private RectTransform demandsRect;

    private int pageIndex = 0;
    private Vector2 _dragBegin, _dragEnd;
    
    private void Awake()
    {
        demands = body.GetComponentsInChildren<DemandsController>();
        demandsRect = demandsContainer.GetComponent<RectTransform>();
    }

 

    public void EnableUI() {
        pageIndex = 0;
        Init();
    }

    private void Init() {
        foreach (var page in demands) { 
            page.gameObject.SetActive(false);
        }
        SetPageIconWhite(pageIndex);
    }

    private void SetPageIconWhite(int index) {
        footer.transform.GetChild(index).GetComponent<Image>().color = Color.white;  
    }

    private void SetPageIconBlack(int index) {
        footer.transform.GetChild(index).GetComponent<Image>().color = Color.black;
    }

    public void NextPage() {
        if (pageIndex == demandsContainer.transform.childCount - 1) return;
        SetPageIconBlack(pageIndex);
        UpdatePageIndex(1);
        SetPageIconWhite(pageIndex);
        
        var toScroll = demandsRect.sizeDelta / demandsContainer.transform.childCount;
        var targetPosition = demandsRect.anchoredPosition + new Vector2(-toScroll.x, 0);

        StartCoroutine(LerpRectPosition(targetPosition, 0.2f));
    }

    public void PrevPage() {
        if (pageIndex == 0) return;
        SetPageIconBlack(pageIndex);
        UpdatePageIndex(-1);
        SetPageIconWhite(pageIndex);
       
        var toScroll = demandsRect.sizeDelta / demandsContainer.transform.childCount;
        var targetPosition = demandsRect.anchoredPosition + new Vector2(toScroll.x, 0);

        StartCoroutine(LerpRectPosition(targetPosition, 0.2f));
    }

    private IEnumerator LerpRectPosition( Vector2 targetPosition, float duration)
    {
        float elapsedTime = 0;
        Vector2 startingPosition = demandsRect.anchoredPosition;

        while (elapsedTime < duration)
        {
            demandsRect.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        demandsRect.anchoredPosition = targetPosition;
    }

 

    private void UpdatePageIndex(int value) { 
        pageIndex = (pageIndex + value) % demands.Length;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var direction = _dragEnd - _dragBegin;
        
        if (direction.x > 0)
        {
            PrevPage();
            
        }
        else {
            NextPage();
            
        }
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragBegin = eventData.pressPosition;
        Debug.Log("beginDrag: " + _dragEnd);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragEnd = eventData.position;
        
       
    }
}
