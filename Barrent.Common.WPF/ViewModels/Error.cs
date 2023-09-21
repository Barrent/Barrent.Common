namespace Barrent.Common.WPF.ViewModels;

public class Error<T>
{
    private readonly ErrorPredicate<T> _errorCondition;

    public Error(string propertyName, string message, ErrorPredicate<T> errorCondition)
    {
        Message = message;
        _errorCondition = errorCondition;
        PropertyName = propertyName;
    }

    public string PropertyName { get; }

    public string Message { get; }

    public bool Detect(T parameter)
    {
        return _errorCondition(parameter);
    }
}