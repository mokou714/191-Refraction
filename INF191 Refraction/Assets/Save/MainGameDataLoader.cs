using UnityEngine;
using UnityEngine.UI;

public class MainGameDataLoader : DataLoader
{
    //targets
    [SerializeField] private RawImage userProfile;
    [SerializeField] private Text userId;
    
    //resources
    public Sprite[] profileImages;

    protected override void LoadData()
    {
        if (Data.userData == null) return;

        userProfile.texture = profileImages[Data.userData.profileImageIndex].texture;
        userId.text = Data.userData.accountId;
    }
    
}
