using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public float minx;
    public float maxx;
    public float minz;
    public float maxz;

    public Transform barrel;
    public Transform fallenBarrel;
    public Transform chair;
    public Transform largePot;
    public Transform smallPot;
    public Transform skull;
    public Transform table;
    public Transform chest;
    public Transform lantern;

    private ObjectInfo barrelInfo;
    private ObjectInfo fallenBarrelInfo;
    private ObjectInfo chairInfo;
    private ObjectInfo smallPotInfo;
    private ObjectInfo largePotInfo;
    private ObjectInfo skullInfo;
    private ObjectInfo tableInfo;
    private ObjectInfo chestInfo;
    private ObjectInfo lanternInfo;

    private float sizex;
    private float sizez;

    void Start ()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        sizex = maxx - minx;
        sizez = maxz - minz;

        barrelInfo = barrel.GetComponent<ObjectInfo>();
        fallenBarrelInfo = fallenBarrel.GetComponent<ObjectInfo>();
        chairInfo = chair.GetComponent<ObjectInfo>();
        smallPotInfo = smallPot.GetComponent<ObjectInfo>();
        largePotInfo = largePot.GetComponent<ObjectInfo>();
        skullInfo = skull.GetComponent<ObjectInfo>();
        tableInfo = table.GetComponent<ObjectInfo>();
        chestInfo = chest.GetComponent<ObjectInfo>();
        lanternInfo = lantern.GetComponent<ObjectInfo>();

        Generate();
    }

    private void Generate()
    {
        if (barrel != null)
        {
            GenerateSkull(0.0f, skullInfo.offset, 0.0f, Random.Range(30, 60));

            GenerateLargePot(0.05f + Rand(), largePotInfo.offset, 1.0f - Rand());
            GenerateLargePot(0.0f + Rand(), largePotInfo.offset, 0.88f - Rand());

            GenerateBarrel(1.0f - Rand(), barrelInfo.offset, 0.0f + Rand());
            if (Lucky(0.5f))
            {
                GenerateBarrel(0.85f - Rand(), barrelInfo.offset, 0.0f + Rand());
            }
            if (Lucky(0.2f))
            {
                GenerateBarrel(1.0f - Rand(), barrelInfo.offset, 0.15f + Rand());
            }
            else
            {
                GenerateFallenBarrel(0.9f - Rand(), fallenBarrelInfo.offset, 0.15f + Rand(), Random.Range(120, 150));
            }

            GenerateBarrel(1.0f - Rand(), barrelInfo.offset, 1.0f - Rand());
            GenerateChair(0.97f - Rand(), chairInfo.offset, 0.83f - Rand());

            GenerateTable(0.5f - Rand(), chairInfo.offset, 0.9f - Rand(), Random.Range(-30, 30));
        }
    }

    private void GenerateBarrel(float x, float y, float z)
    {
        InstantiateObject(barrel, x, y, z, Random.Range(0, 360));
    }

    private void GenerateFallenBarrel(float x, float y, float z, float roty)
    {
        InstantiateObject(fallenBarrel, x, y, z, roty);
    }

    private void GenerateChair(float x, float y, float z)
    {
        InstantiateObject(chair, x, y, z, Random.Range(0, 360));
    }

    private void GenerateSkull(float x, float y, float z, float roty)
    {
        InstantiateObject(skull, x, y, z, roty);
    }

    private void GenerateLargePot(float x, float y, float z)
    {
        InstantiateObject(largePot, x, y, z, Random.Range(0, 360));
    }

    private void GenerateTable(float x, float y, float z, float roty)
    {
        Transform tab = InstantiateObject(table, x, y, z, 0);
        float tablex = tableInfo.x;
        float tablez = tableInfo.z;

        Transform ch = InstantiateObject(chest, x, y, z, roty + 180 + Random.Range(-30, 30));
        ch.position = new Vector3(
            ch.position.x - tablex + Random.Range(0, tablex / 4),
            ch.position.y + tableInfo.height + chestInfo.offset,
            ch.position.z + Random.Range(-tablez, tablez));
        ch.SetParent(tab);

        Transform sk = InstantiateObject(skull, x, y, z, roty + 180 + Random.Range(-30, 30));
        sk.position = new Vector3(
            sk.position.x + tablex - Random.Range(0, tablex / 4),
            sk.position.y + tableInfo.height + skullInfo.offset,
            sk.position.z + Random.Range(-tablez, 0));
        sk.SetParent(tab);

        Transform la = InstantiateObject(lantern, x, y, z, Random.Range(0, 360));
        la.position = new Vector3(
            la.position.x + (tablex / 2) - Random.Range(0, tablex / 4),
            la.position.y + tableInfo.height + lanternInfo.offset,
            la.position.z + Random.Range(0, tablez));
        la.SetParent(tab);

        tab.eulerAngles = new Vector3(tab.eulerAngles.x, roty, tab.eulerAngles.z);
    }

    private float Rand()
    {
        return Random.Range(0.0f, 0.02f);
    }

    private bool Lucky(float threshold)
    {
        return Random.Range(0.0f, 1.0f) < threshold;
    }

    private Transform InstantiateObject(Transform transform, float x, float y, float z, float roty)
    {
        Transform obj = Instantiate(transform);
        obj.position = new Vector3(x * sizex + minx, y, z * sizez + minz);
        obj.eulerAngles = new Vector3(obj.eulerAngles.x, roty, obj.eulerAngles.z);
        obj.parent = this.transform;
        return obj;
    }
}
