using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class energyRay : MonoBehaviour
{
    
    public int charge =0;
    public int maxCharge = 120;
    public Transform firePoint;
    public int damage = 100;
    public LineRenderer lineRenderer;

    public EnergyBarPlayer energyBarPlayer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (charge >= 100f && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Shoot());
        }
    }

    public void incCharge(int x)
    {
        if (charge < maxCharge)
        {
            charge += x;
            energyBarPlayer.setEnergy(charge);
        }
        
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.right);

        if (hitInfo)
        {   
            lineRenderer.SetPosition(0,firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            Boss boss = hitInfo.transform.GetComponent<Boss>();
            if (boss != null)
            {
                boss.Damage(damage);
            }
        }

        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right*100);
        }

        lineRenderer.enabled = true;
        charge  -= 100;
        energyBarPlayer.setEnergy(charge);

        yield return new WaitForSeconds(0.2f);

        lineRenderer.enabled = false;
    }

}
