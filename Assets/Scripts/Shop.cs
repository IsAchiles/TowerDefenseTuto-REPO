using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TMP_Text standardTurretCostText;
    public TurretBlueprint missileLauncher;
    public TMP_Text missileLauncherCostText;
    public TurretBlueprint laserBeamer;
    public TMP_Text laserBeamerCostText;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        standardTurretCostText.text = "R$" + standardTurret.cost.ToString();
        missileLauncherCostText.text = "R$" + missileLauncher.cost.ToString();
        laserBeamerCostText.text = "R$" + laserBeamer.cost.ToString();
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncherTurret()
    {
        Debug.Log("Missile Launcher Turret Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
