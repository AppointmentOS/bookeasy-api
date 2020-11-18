namespace Bookeasy.Application.Common.Interfaces
{
    public interface IIrisDbContext
    {
        IUserCollection User { get; }
        IPostCollection Post { get; }
        ICommentCollection Comment { get; }
    }
}
