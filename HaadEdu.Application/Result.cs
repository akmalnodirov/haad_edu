namespace HaadEdu.Application;

internal class Result<T> where T : class
{
    public T? Value { get; set; }
}
