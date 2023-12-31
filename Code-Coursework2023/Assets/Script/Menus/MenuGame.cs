using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using System.IO;
using TMPro;

public class MenuGame : MonoBehaviourPunCallbacks
{
    public static bool OnlineOffline = false;
    public TMP_Text offonline;

    [Header("Menu Panel")]
    [SerializeField] private GameObject MenuPause;
    [SerializeField] public static GameObject MenuPauses;
    [SerializeField] private GameObject MenuInventory;
    [SerializeField] private GameObject MenuItemsOnFlour;
    [SerializeField] public GameObject MenuItemsOnFlourButton;
    [SerializeField] private GameObject HotBarMenu;
    [SerializeField] private GameObject YouPlayerPrefab;
    [SerializeField] private GameObject YouPlayerPrefabTwo;
    [SerializeField] private GameObject InteractiveButton;
    [SerializeField] private Slider OnOffMusic;
    [SerializeField] private AudioSource audio;

    [Header("Menu Items on Flour")]
    public Transform content;
    public GameObject slots;

    void Start()
    {
        MenuPause.SetActive(true);
        MenuInventory.SetActive(true);
        MenuItemsOnFlour.SetActive(true);

        if (OnlineOffline)
        {
            offonline.text = "Online";
        }
        else
        {
            offonline.text = "Offline";
            if (PlayerManager.YouPerson == "PlayerPrefab")
            {
                Instantiate(YouPlayerPrefab);
            }
            if (PlayerManager.YouPerson == "PlayerPrefabTwo")
            {
                Instantiate(YouPlayerPrefabTwo);
            }
            Debug.Log("Offline");
        }
        InventoryManager.InteractiveButton = InteractiveButton;
        InventoryManager.menuInventory = MenuInventory;
        MenuOnFlour.menuItemsOnFlour = MenuItemsOnFlour;
        ItemsOnFlourScript.menuItemsOnFlourButton = MenuItemsOnFlourButton;
        MenuOnFlour.content = content;
        MenuOnFlour.slots = slots;

        MenuPauses = MenuPause;

        MenuPause.SetActive(false);
        MenuInventory.SetActive(false);
        MenuItemsOnFlour.SetActive(false);
    }

    public void OpenMenuPauseButton()
    {
        MenuPause.SetActive(true);
        audio = vThirdPersonCamera.target.Find("Audio Source").GetComponent<AudioSource>();
        InventoryManager.Mapa.SetActive(false);
    }
    public void CloseMenuPauseButton()
    {
        MenuPause.SetActive(false);
        InventoryManager.Mapa.SetActive(true);
    }
    public void OpenMenuInventoryButton()
    {
        MenuInventory.SetActive(true);
        InventoryManager.Mapa.SetActive(false);
    }
    public void CloseMenuInventoryButton()
    {
        InventoryManager.idSelectedInv = 0;
        InventoryManager.idSelectedQuickBarInv = 0;
        MenuInventory.SetActive(false);
        InventoryManager.Mapa.SetActive(true);
    }
    public void OpenMenuItemsOnFlour()
    {
        MenuItemsOnFlour.SetActive(true);
        MenuOnFlour.UpdateItemsOnFlour(ItemsOnFlourScript.CountItemsInFlour, ItemsOnFlourScript.objectsInTrigger);
    }
    public void CloseMenuItemsOnFlour()
    {
        MenuOnFlour.DestroyChild();
        MenuOnFlour.listsFlour.Clear();
        MenuOnFlour.countItemsOn = 0;
        MenuOnFlour.iDSelectedOnFlourInt = 0;
        MenuItemsOnFlour.SetActive(false);
    }
    private void Update()
    {
        if (OnOffMusic.value == 0)
        {
            audio.volume = 0;
        }
        else
        {
            audio.volume = 1;
        }
    }

    public void DisconnectButton()
    {
        if (OnlineOffline)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("MainMenu");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        SceneManager.LoadScene("MainMenu");
    }
}
