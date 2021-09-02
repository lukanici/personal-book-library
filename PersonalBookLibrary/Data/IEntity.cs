using System;
namespace PersonalBookLibrary.Data
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedUtc { get; set; }
        DateTime ModifiedUtc { get; set; }
    }
}
