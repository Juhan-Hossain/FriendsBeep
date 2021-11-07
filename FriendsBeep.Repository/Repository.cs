using FriendsBeep.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FriendsBeep.Repository
{
    public abstract class Repository<T, AppDbContext> : IRepository<T>
        where T : class
        where AppDbContext : DbContext
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<T>> Add(T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                serviceResponse.Data = unit;
                await _dbContext.Set<T>().AddAsync(serviceResponse.Data);
                await _dbContext.SaveChangesAsync();
                serviceResponse.Message = "unit created successfully in DB";

            }
            catch (Exception exception)
            {
                serviceResponse.Message = $"Storing action failed in the database for given unit\n" +
                    $"Error Message: {exception.Message}";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public ServiceResponse<T> Delete(T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            try
            {
                _dbContext.Set<T>().Remove(unit);
                _dbContext.SaveChanges();
                serviceResponse.Message = "Unit deleted successfully";
                serviceResponse.Data = unit;
            }
            catch (Exception)
            {
                serviceResponse.Message = "Unit delete request failed";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public ServiceResponse<T> DeleteById(int? id)
        {
            var serviceResponse = new ServiceResponse<T>();
            serviceResponse.Data = _dbContext.Set<T>().Find(id);
            if (id != null)
            {
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = "Bad request occured for given id";
                    serviceResponse.Success = false;
                }
                else
                {
                    _dbContext.Set<T>().Remove(serviceResponse.Data);
                    serviceResponse.Message = "Data  with the given id was found & deleted " +
                        "in serviceResponse.Data";
                }
            }
            else
            {
                serviceResponse.Message = "Bad request occured for null id";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public ServiceResponse<IQueryable<T>> FindDDL(Expression<Func<T, bool>> expression)
        {
            var serviceResponse = new ServiceResponse<IQueryable<T>>();
            var result = _dbContext.Set<T>().Where(expression);
            if (result != null)
            {
                serviceResponse.Data = result;
                serviceResponse.Message = "loaded data sucessfully";
            }
            else
            {
                serviceResponse.Message = "no data found to load";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<T>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<T>>();
            try
            {
                serviceResponse.Data = await _dbContext.Set<T>().ToListAsync();
                serviceResponse.Message = "Data loaded in ServiceResponse.Data Successfully";
            }
            catch (Exception exception)
            {

                serviceResponse.Message = "Error occurred while loading data.\nError message: " + exception.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> GetById(int? id)
        {
            var serviceResponse = new ServiceResponse<T>();

            serviceResponse.Data = await _dbContext.Set<T>().FindAsync(id);
            if (id != null)
            {
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = "Bad request occured for given id";
                    serviceResponse.Success = false;
                }
                else serviceResponse.Message = "Data  with the given id was found & loaded";
            }
            else
            {
                serviceResponse.Message = "Bad request occured for null id";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public ServiceResponse<T> Update(T unit)
        {
            var serviceResponse = new ServiceResponse<T>();

            if (unit is T)
            {
                serviceResponse.Data = _dbContext.Set<T>().Update(unit) as T;
                _dbContext.SaveChanges();
                serviceResponse.Message = "Unit Updated successfully in DB";
            }
            else if (unit is T != true)
            {
                serviceResponse.Message = "given unit is invalid";
                serviceResponse.Success = false;
            }
            else
            {
                serviceResponse.Message = "Updating action failed in the database for given unit";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public ServiceResponse<T> Update(int id, T unit)
        {
            var serviceResponse = new ServiceResponse<T>();
            int UnitId = (int)unit.GetType().GetProperty("Id").GetValue(unit);
            var p = _dbContext.Set<T>().Find(id);
            if (id != UnitId)
            {
                serviceResponse.Data = unit;
                serviceResponse.Message = "Bad update request for given id!!!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            else
            {
                _dbContext.Entry(unit).State = EntityState.Modified;
                _dbContext.SaveChanges();
                serviceResponse.Data = unit;
                serviceResponse.Message = "Update Success!!!";
            }
            return serviceResponse;
        }

        
    }
}
