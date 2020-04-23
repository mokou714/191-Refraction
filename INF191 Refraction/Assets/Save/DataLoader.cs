using UnityEngine;

public abstract class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    protected abstract void LoadData();
}
