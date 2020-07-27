using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{
    public string m_line;
    public Transform m_content;
    public Transform m_Canvas;
    public GameObject m_Pref;
    private Vector2 m_Size;
    public Vector3 m_offset;

    private void Start()
    {
        m_Size = m_Pref.GetComponent<RectTransform>().sizeDelta;
        //CreateTable();
    }

    public void CreateTable()
    {
        if(m_content != null)
            Destroy(m_content.gameObject);
        
        m_content = new GameObject().transform;
        m_content.SetParent(m_Canvas);
        m_line = File.ReadAllText(Application.dataPath + "/StreamingAssets/JsonChallenge.json");
        JSONNode my_Json = JSON.Parse(m_line);

        CreateUI(0,0, true, my_Json[0]);
        ParseMyJson(my_Json[1], -1, true);
        for (int j = 0; j < my_Json[1].Count; j++)
        {
            ParseMyJson(my_Json[2][j], -2 - j, false);
        }
    }

    void ParseMyJson(JSONNode m_Json, int y, bool isCaps)
    {
        for (int i = 0; i < m_Json.Count; i++)
        {
            CreateUI(i, y, isCaps, m_Json[i]);
        }
    }

    public void CreateUI(int x, int y, bool isCaps, string text)
    {
        GameObject go = Instantiate(m_Pref, new Vector3(x*m_Size.x, y*m_Size.y, 0)+m_offset, Quaternion.identity, m_content);
        Text txt = go.GetComponentInChildren<Text>();
        txt.text = text;
        if (isCaps)
        {
            txt.fontSize = 24;
            txt.fontStyle = FontStyle.Bold;
        }
        else
        {
            txt.fontSize = 18;
            txt.fontStyle = FontStyle.Normal;
        }
    }
}