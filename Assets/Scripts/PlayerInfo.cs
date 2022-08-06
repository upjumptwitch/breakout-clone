using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] Text NameTextField; 
    private string m_Name;
    public string Name { get { return m_Name; } }
    public static PlayerInfo Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetName()
    {
        m_Name = NameTextField.text;
        SceneManager.LoadScene(1);
    }

}
