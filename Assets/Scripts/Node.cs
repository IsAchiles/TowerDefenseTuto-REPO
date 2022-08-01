using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //Cor definida dentro do jogo - Cor ao passar o mouse em cima do node
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]

    public GameObject turret;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;

    //Metodo que vai rodar no começo do jogo
    void Start()
    {
        rend = GetComponent<Renderer>();
        //Define a cor inicial como a cor do node
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    //Ao clicar com o mouse
    void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    //Ao passar o mouse em cima do node
    void OnMouseEnter() 
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        //Define a cor do node como a cor definida dentro da engine
        
    }

    //Ao tirar o mouse de cima do node
    void OnMouseExit()
    {
        //Volta a cor inicial
        rend.material.color = startColor;
    }
}