﻿using HomeServices.Domain.Entities;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service> GetByIdAsync(int id);
    Task AddAsync(Service service);
    Task UpdateAsync(Service service);
    Task DeleteAsync(int id);
}