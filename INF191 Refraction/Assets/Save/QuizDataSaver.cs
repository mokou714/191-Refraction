
public class QuizDataSaver : DataSaver
{
    //how to save quiz data?
    protected override void SaveData()
    {
        if (Data.userData == null) return;
        Data.userData.quizComplete = true;
    }
}