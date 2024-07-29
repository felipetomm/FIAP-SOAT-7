namespace FIAP.Domain.Entities.Base;

public class DomainValidationResult
{
    private List<string> Errors { get; set; } = [];

    /// <summary>
    /// Check if has any error
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return Errors.Count == 0;
    }

    public bool IsInvalid()
    {
        return !IsValid();
    }

    /// <summary>
    /// Add new error to list
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public DomainValidationResult AddError(string error)
    {
        Errors.Add(error);

        return this;
    }

    /// <summary>
    /// Returns a concatenated string with all errors result for domain validation
    /// </summary>
    /// <returns></returns>
    public string GetErrorsMessage()
    {
        return string.Join("; ", Errors);
    }
}