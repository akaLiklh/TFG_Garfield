using System.Collections.Generic;
using UnityEngine;

public enum PanelID
{
    MainMenu, SaveSelect, Character, Settings, Controls,
    HUD, Inventory, Skills, Shop, Dialogue, Pause, Loading
}

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public struct PanelEntry
    {
        public PanelID id;
        public GameObject panel;
    }

    [SerializeField] List<PanelEntry> panels;
    Dictionary<PanelID, GameObject> dic = new();

    void Awake()
    {
        foreach (var p in panels) dic[p.id] = p.panel;
        HideAll();                   
    }

    void Start() => Show(PanelID.MainMenu);  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) Toggle(PanelID.Inventory);
        if (Input.GetKeyDown(KeyCode.K)) Toggle(PanelID.Skills);
        if (Input.GetKeyDown(KeyCode.Escape)) Toggle(PanelID.Pause);
    }

    // --- Lógica base ---
    public void HideAll()
    {
        foreach (var p in dic.Values) p.SetActive(false);
    }

    // Abre una pantalla completa y cierra todo lo demás
    public void Show(PanelID id)
    {
        HideAll();
        Time.timeScale = 1f;
        dic[id].SetActive(true);
    }

    // Abre/cierra una ventana sin tocar el resto (pausa el juego)
    public void Toggle(PanelID id)
    {
        if (!dic[PanelID.HUD].activeSelf) return;   // solo si estás jugando
        bool open = !dic[id].activeSelf;
        dic[id].SetActive(open);
        Time.timeScale = open ? 0f : 1f;
    }

    public void Open(PanelID id) => dic[id].SetActive(true);
    public void Close(PanelID id) => dic[id].SetActive(false);

    // --- Métodos para los botones (el Inspector no admite enums) ---
    public void GoMainMenu() => Show(PanelID.MainMenu);
    public void GoSaveSelect() => Show(PanelID.SaveSelect);
    public void GoCharacter() => Show(PanelID.Character);
    public void GoSettings() => Show(PanelID.Settings);
    public void OpenControls() => Open(PanelID.Controls);
    public void CloseControls() => Close(PanelID.Controls);
    public void StartGame() => Show(PanelID.HUD);
    public void ResumeGame() { Close(PanelID.Pause); Time.timeScale = 1f; }
    public void OpenShop() { Open(PanelID.Shop); Time.timeScale = 0f; }
    public void CloseShop() { Close(PanelID.Shop); Time.timeScale = 1f; }
    public void QuitGame() => Application.Quit();
}