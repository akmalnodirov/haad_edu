namespace HaadEdu.Application.HaadEduException;
public class CustomException(int Code, string massage) : Exception(massage) 
{
    public int StatusCode { get; set; } = Code;
}
