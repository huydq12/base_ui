using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("InventoryManager");
                instance = obj.AddComponent<InventoryManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
        DontDestroyOnLoad(gameObject);
    }

    public int GetCoin()
    {
        return GameManager.Instance.userData.playerCash;
    }

    public int GetDiamond()
    {
        return GameManager.Instance.userData.playerDiamond;
    }

    public int GetHealth()
    {
        return GameManager.Instance.userData.playerHealth;
    }

    public int GetBoosterType1()
    {
        return GameManager.Instance.userData.boosterType1;
    }

    public int GetBoosterType2()
    {
        return GameManager.Instance.userData.boosterType2;
    }

    public int GetBoosterType3()
    {
        return GameManager.Instance.userData.boosterType3;
    }

    public void AddCoin(int amount)
    {
        GameManager.Instance.userData.playerCash += amount;
        GameManager.Instance.userData.Save();
    }

    public void AddDiamond(int amount)
    {
        GameManager.Instance.userData.playerDiamond += amount;
        GameManager.Instance.userData.Save();
    }

    public void AddHealth(int amount)
    {
        GameManager.Instance.userData.playerHealth += amount;
        GameManager.Instance.userData.Save();
    }

    public void AddBoosterType1(int amount)
    {
        GameManager.Instance.userData.boosterType1 += amount;
        GameManager.Instance.userData.Save();
    }

    public void AddBoosterType2(int amount)
    {
        GameManager.Instance.userData.boosterType2 += amount;
        GameManager.Instance.userData.Save();
    }

    public void AddBoosterType3(int amount)
    {
        GameManager.Instance.userData.boosterType3 += amount;
        GameManager.Instance.userData.Save();
    }

    public bool SpendCoin(int amount)
    {
        if (GameManager.Instance.userData.playerCash >= amount)
        {
            GameManager.Instance.userData.playerCash -= amount;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool SpendDiamond(int amount)
    {
        if (GameManager.Instance.userData.playerDiamond >= amount)
        {
            GameManager.Instance.userData.playerDiamond -= amount;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool SpendHealth(int amount)
    {
        if (GameManager.Instance.userData.playerHealth >= amount)
        {
            GameManager.Instance.userData.playerHealth -= amount;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool UseBoosterType1()
    {
        if (GameManager.Instance.userData.boosterType1 > 0)
        {
            GameManager.Instance.userData.boosterType1--;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool UseBoosterType2()
    {
        if (GameManager.Instance.userData.boosterType2 > 0)
        {
            GameManager.Instance.userData.boosterType2--;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool UseBoosterType3()
    {
        if (GameManager.Instance.userData.boosterType3 > 0)
        {
            GameManager.Instance.userData.boosterType3--;
            GameManager.Instance.userData.Save();
            return true;
        }
        return false;
    }

    public bool HasEnoughCoin(int amount)
    {
        return GameManager.Instance.userData.playerCash >= amount;
    }

    public bool HasEnoughDiamond(int amount)
    {
        return GameManager.Instance.userData.playerDiamond >= amount;
    }

    public bool HasEnoughHealth(int amount)
    {
        return GameManager.Instance.userData.playerHealth >= amount;
    }

    public bool HasBoosterType1()
    {
        return GameManager.Instance.userData.boosterType1 > 0;
    }

    public bool HasBoosterType2()
    {
        return GameManager.Instance.userData.boosterType2 > 0;
    }

    public bool HasBoosterType3()
    {
        return GameManager.Instance.userData.boosterType3 > 0;
    }
}
