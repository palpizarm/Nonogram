using UnityEngine;
using UnityEngine.UI;

public class VerticalClues : MonoBehaviour
{

    private Reader reader = Reader.getInstace();

    private int columns;
    private int[][] clues;
    private float width;
    public GameObject parent;
    public Font font;
    public GameObject template;

    // Start is called before the first frame update
    void Start()
    {
        columns = reader.getColums();
        clues = reader.getColumnsHints();
        width = parent.GetComponent<RectTransform>().sizeDelta[0] / columns;

        for (int row = 0; row < columns; row++)
        {
            GameObject textUI = new GameObject();
            textUI.transform.SetParent(parent.GetComponent<RectTransform>());
            textUI.name = "ROW: " + row;
            Text text = textUI.AddComponent<Text>();
            string content = "";
            for (int index = 0; index < clues[row].Length; index++)
            {
                if (index == clues[row].Length - 1)
                {
                    content += clues[row][index];
                }
                else
                {
                    content += clues[row][index].ToString() + "\n";
                }
            }
            text.text = content;
            if (clues[row].Length > 4)
            {
                text.fontSize = 12;
            } else
            {
                text.fontSize = 20;
            }
            text.fontStyle = FontStyle.Bold;
            text.color = Color.white;
            text.font = font;
            text.alignment = TextAnchor.LowerCenter;
            textUI.transform.localScale = new Vector3(1, 1, 1);
            Vector3 position = template.GetComponent<RectTransform>().anchoredPosition3D;
            position[0] += row * width + width / 2;
            textUI.GetComponent<RectTransform>().anchoredPosition3D = position;
            textUI.GetComponent<RectTransform>().sizeDelta = new Vector2(21.5f, 100f);
        }
        
    }
}
