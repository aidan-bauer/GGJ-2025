using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDeployer : MonoBehaviour
{

    [SerializeField] GameObject shield;

    [SerializeField] GameObject shieldPreview;
    [SerializeField] List<GameObject> deployedShields;

    private void Awake()
    {
        deployedShields = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (shieldPreview.activeSelf)
        {
            shieldPreview.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPreview()
    {
        shieldPreview.SetActive(true);
    }

    public void MovePreview(Vector3 pos)
    {
        shieldPreview.transform.position = pos;
    }

    public void DestroyPreview()
    {
        shieldPreview.SetActive(false);
    }

    public void DeployShield(Vector3 spawnPos)
    {
        if (deployedShields.Count == DontDestroy.inst.Constants.maxDeployedShields)
        {
            Destroy(deployedShields[0].gameObject);
            deployedShields.RemoveAt(0);
        }

        GameObject newShield = Instantiate(shield, spawnPos, Quaternion.identity);
        deployedShields.Add(newShield);
    }
}
