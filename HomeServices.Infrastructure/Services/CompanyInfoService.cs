using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Infrastructure.Services
{
    using AutoMapper;
    using HomeServices.Application.DTOs;
    using HomeServices.Application.Interfaces;
    using HomeServices.Domain.Entities;

    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository _repo;
        private readonly IMapper _mapper;

        public CompanyInfoService(ICompanyInfoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyInfoDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<CompanyInfoDto>>(await _repo.GetAllAsync());

        public async Task<CompanyInfoDto?> GetByIdAsync(int id) =>
            _mapper.Map<CompanyInfoDto?>(await _repo.GetByIdAsync(id));

        public async Task AddAsync(CompanyInfoDto dto) =>
            await _repo.AddAsync(_mapper.Map<CompanyInfo>(dto));

        public async Task UpdateAsync(CompanyInfoDto dto) =>
            await _repo.UpdateAsync(_mapper.Map<CompanyInfo>(dto));

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);
    }

}
