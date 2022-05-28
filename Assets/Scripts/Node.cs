using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //Cor definida dentro do jogo - Cor ao passar o mouse em cima do node
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;

    private Color startColor;

    //Metodo que vai rodar no começo do jogo
    void Start()
    {
        rend = GetComponent<Renderer>();
        //Define a cor inicial como a cor do node
        startColor = rend.material.color;
    }


    //Ao clicar com o mouse
    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        //Build a turret

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    //Ao passar o mouse em cima do node
    void OnMouseEnter() {
        //Define a cor do node como a cor definida dentro da engine
        rend.material.color = hoverColor;
    }

    //Ao tirar o mouse de cima do node
    void OnMouseExit()
    {
        //Volta a cor inicial
        rend.material.color = startColor;
    }
}