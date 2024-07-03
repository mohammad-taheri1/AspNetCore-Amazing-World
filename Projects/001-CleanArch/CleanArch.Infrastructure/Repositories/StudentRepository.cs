using CleanArch.Domain.Entities;
using CleanArch.Domain.IRepositories;
using CleanArch.Infrastructure.Persistence.MSSQLServer;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    #region Constructor & DI
    private readonly AppMSSQLDbContext _appMSSQLDbContext;

    public StudentRepository(AppMSSQLDbContext appMSSQLDbContext)
    {
        _appMSSQLDbContext = appMSSQLDbContext;
    }
    #endregion

    public async Task<List<Student>> GetAll()
    {
        var list = await _appMSSQLDbContext.Students.ToListAsync();
        return list;
    }

    public async Task<Student?> GetByIdAsync(long id)
    {
        var student = await _appMSSQLDbContext.Students.Where(q => q.Id == id).FirstOrDefaultAsync();
        return student;
    }

    public async Task<long> CreateAsync(Student student)
    {
       await _appMSSQLDbContext.Students.AddAsync(student);
        await _appMSSQLDbContext.SaveChangesAsync();
        return student.Id;
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        _appMSSQLDbContext.Entry(student).State = EntityState.Modified;
        await _appMSSQLDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var student = await GetByIdAsync(id);
        if(student is not null)
        {
            _appMSSQLDbContext.Students.Remove(student);
            await _appMSSQLDbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> IsExistsByIdAsync(long id)
    {
        var student = await GetByIdAsync(id);
        return student is not null;
    }
}