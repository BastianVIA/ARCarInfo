using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelViewController : MonoBehaviour
{
    [SerializeField]
    private DemandsController[] pages;

    [SerializeField]
    private GameObject body, demandsContainer, footer, iconPrefab;

    private RectTransform demandsRect;

    private int pageIndex = 0;
    private int numberOfPages = 0;
    
    private void Awake()
    {
        pages = body.GetComponentsInChildren<DemandsController>();
        demandsRect = demandsContainer.GetComponent<RectTransform>();
        numberOfPages = pages.Length;
        SetupFooter();
    }

    private void SetupFooter() { 
        for (int i = 0; i < numberOfPages; i++)
        {
            Instantiate(iconPrefab, footer.transform);
        }
    }

    private void OnEnable()
    {
        ActivatePages();
        SetFirstPage();
    }

    private void SetFirstPage() { 
        pageIndex = 0;
        SetPageIconWhite(pageIndex);
    }

    private void ActivatePages() {
        foreach (var page in pages)
        {
            page.gameObject.SetActive(true);
        }
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

        StartCoroutine(ShiftDemandsRect(targetPosition, 0.2f));
    }

    public void PrevPage() {
        if (pageIndex == 0) return;
        SetPageIconBlack(pageIndex);
        UpdatePageIndex(-1);
        SetPageIconWhite(pageIndex);
       
        var toScroll = demandsRect.sizeDelta / demandsContainer.transform.childCount;
        var targetPosition = demandsRect.anchoredPosition + new Vector2(toScroll.x, 0);

        StartCoroutine(ShiftDemandsRect(targetPosition, 0.2f));
    }

    private IEnumerator ShiftDemandsRect( Vector2 targetPosition, float duration)
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
        pageIndex = (pageIndex + value) % pages.Length;
    }
}
