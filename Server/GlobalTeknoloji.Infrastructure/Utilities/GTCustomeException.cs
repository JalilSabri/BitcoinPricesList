namespace GlobalTeknoloji.Infrastructure.Utilities;

public class GTCustomeException : ApplicationException
{
    private string _repositoryName;
    public GTCustomeException(string msg, string RepositoryName) : base(msg)
    {
        this._repositoryName = RepositoryName;
    }

    public override string Message => $"{base.Message} \n Exception is triggered in Repository: {_repositoryName}.";
}
