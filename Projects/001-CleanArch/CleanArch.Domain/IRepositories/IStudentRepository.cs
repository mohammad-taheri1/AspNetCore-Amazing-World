using CleanArch.Domain.Entities;

namespace CleanArch.Domain.IRepositories;

public interface IStudentRepository
{
    Task<List<Student>> GetAll();
    Task<Student?> GetByIdAsync(long id);
    Task<long> CreateAsync(Student student);
    Task<bool> UpdateAsync(Student student);
    Task<bool> DeleteAsync(long id);
    Task<bool> IsExistsByIdAsync(long id);
}
