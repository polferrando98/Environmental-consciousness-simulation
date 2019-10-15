using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Graph : MonoBehaviour {

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    GameManager gm;

    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        gm = FindObjectOfType<GameManager>();
    }
    public void renderPlot()
    {
        List<int> xAxis = new List<int>();
        for(int i=0; i<Parameters.DaysToSimulate; i++)
            xAxis.Add(2);
        ShowGraph(xAxis, new Color(1, 1, 1, 0.5f));

        List<int> trees = Variables.trees;
        ShowGraph(trees, Color.green);
        List<int> humans = Variables.humans;
        ShowGraph(humans, Color.cyan);
        List<int> contamination = new List<int>();
        for (int i = 0; i < Variables.contamination.Count; i++)
            contamination.Add((int)(Variables.contamination[i]*30f));
        ShowGraph(contamination, Color.red);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(3, 3);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }
    
    private void ShowGraph(List<int> valueList, Color color) {
        float yMaximum = 30f;
        RectTransform rectTransform = GameObject.Find("graphContainer").GetComponent<RectTransform>();
        float graphHeight = (float)rectTransform.rect.height-30f; // graphContainer.sizeDelta.y;
        float xSize = (float)(rectTransform.rect.width -30f) /(Parameters.DaysToSimulate);
        GameObject lastCircleGameObject = null;
     
        for (int i = 0; i < valueList.Count -1; i++)
        {
            float xPosition = 30f + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(color, lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }

    private void CreateDotConnection(Color color, Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 5f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVector(dir));
    }

    private float GetAngleFromVector(Vector2 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
