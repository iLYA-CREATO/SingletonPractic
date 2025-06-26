using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Статическая ссылка на экземпляр синглтона
    private static GameManager _instance;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    // Публичное свойство для доступа к экземпляру
    public static GameManager Instance
    {
        get
        {
            // Если экземпляр ещё не создан, пытаемся найти его на сцене
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // Если не нашли, создаём новый GameObject с этим компонентом
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManager).Name);
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    // Защищаем от создания экземпляра через new
    private GameManager() { }

    // Метод для инициализации (не обязательный)
    private void Awake()
    {
        // Убедимся, что существует только один экземпляр
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // Опционально: сохраняем между сценами
        }
    }

    // Пример метода синглтона
    public void DoSomething()
    {
        textMeshProUGUI.gameObject.SetActive(!textMeshProUGUI.gameObject.activeSelf);
    }
}