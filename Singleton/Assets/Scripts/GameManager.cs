using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����������� ������ �� ��������� ���������
    private static GameManager _instance;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    // ��������� �������� ��� ������� � ����������
    public static GameManager Instance
    {
        get
        {
            // ���� ��������� ��� �� ������, �������� ����� ��� �� �����
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // ���� �� �����, ������ ����� GameObject � ���� �����������
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    // �������� �� �������� ���������� ����� new
    private GameManager() { }

    // ����� ��� ������������� (�� ������������)
    private void Awake()
    {
        // ��������, ��� ���������� ������ ���� ���������
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // �����������: ��������� ����� �������
        }
    }

    // ������ ������ ���������
    public void DoSomething()
    {
        textMeshProUGUI.gameObject.SetActive(!textMeshProUGUI.gameObject.activeSelf);
    }
}