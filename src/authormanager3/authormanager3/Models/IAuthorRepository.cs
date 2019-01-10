using System.Collections.Generic;

namespace authormanager3.Models
{
    public interface IAuthorRepository
    {
        void AddAuthor(Author newAuthor);
        Author GetById(int id);
        List<Author> ListAll();
    }
}