using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private CanvasGroup fadegroup;
    private float fadeInSpeed = 0.33f;
    [SerializeField]
    private GameObject CloseConfirmation;

    public RectTransform menuContainer;
    public Transform PlayMenu;
    public Transform ShopMenu;
    public Transform CharacterMenu;

    private Vector3 MenuPosition;

    public int moveScreenX = 1280;
    public int moveScreenY = 720;


    private void Start()
    {
        fadegroup = FindObjectOfType<CanvasGroup>();

        fadegroup.alpha = 1;

        


    }

    private void Update()
    {
        fadegroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;

        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, MenuPosition, 0.1f);
    }

    private void NavigateToMenu(int menuIndex)
    {
        switch (menuIndex)
        {
            // 0 = main menu
            default:
            case 0:
                MenuPosition = Vector3.zero;
                break;
            //1 = shop
            case 1:
                MenuPosition = Vector3.right * moveScreenX;
                break;
            //2 = play
            case 2:
                MenuPosition = Vector3.left * moveScreenX;
                break;
            //3 = charactersettings
            case 3:
                MenuPosition = Vector3.down * moveScreenY;
                break;
        }
    }

    //buttons
    public void OnCharactersClick()
    {
        NavigateToMenu(3);
        Debug.Log("character clicked");
    }
    public void OnPlayClick()
    {
        NavigateToMenu(2);
        Debug.Log("play clicked");

    }
    public void OnShopClick()
    {
        NavigateToMenu(1);
        Debug.Log("shop clicked"); 
    }
    public void OnBackClick()
    {
        NavigateToMenu(0);
        Debug.Log("go back");
        if(menuContainer.anchoredPosition3D == Vector3.zero)
        {
            CloseConfirmation.SetActive(true);
        }
    }
    public void OnDontStop()
    {
        CloseConfirmation.SetActive(false);
    }

    public void StopClick()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
