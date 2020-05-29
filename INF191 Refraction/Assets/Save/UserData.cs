
public class UserData 
{
        public string accountId; 
        public byte[] password;
        public string firstName;
        public string lastName;
        public int profileImageIndex;
        public bool quizComplete;
        public bool accountSetupComplete;
        public bool isEmployer;
        
        

        public void CopyUserData(UserData userData)
        {
                accountId = userData.accountId;
                password = userData.password;
                firstName = userData.firstName;
                lastName = userData.lastName;
                profileImageIndex = userData.profileImageIndex;
                quizComplete = userData.quizComplete;
                accountSetupComplete = userData.accountSetupComplete;
                isEmployer = userData.isEmployer;

        }

}

public static class Data
{
        public static UserData userData;
}


