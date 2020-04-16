
public class UserData 
{
        public string accountId; 
        public byte[] password;

        public void CopyUserData(UserData userData)
        {
                accountId = userData.accountId;
                password = userData.password;
        }

}

public static class Data
{
        public static UserData userData;
}


