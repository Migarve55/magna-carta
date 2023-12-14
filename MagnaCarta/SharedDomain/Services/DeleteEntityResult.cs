namespace SharedDomain.Services;

public abstract class DeleteEntityResult
{
    public abstract bool IsSuccess { get; }

    public abstract string Error { get; }
    
    public static DeleteEntityResult Success()
    {
        return new SuccessfulDeleteEntityResult();
    }
    
    public static DeleteEntityResult Fail(string msg)
    {
        return new FailedDeleteEntityResult(msg);
    }

    private class SuccessfulDeleteEntityResult : DeleteEntityResult
    {
        public override bool IsSuccess => true;
        public override string Error => string.Empty;
    }

    private class FailedDeleteEntityResult : DeleteEntityResult
    {
        internal FailedDeleteEntityResult(string error)
        {
            Error = error;
        }

        public override bool IsSuccess => false;
        public override string Error { get; }
    }
}