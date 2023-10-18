using SopApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SopApi.Data;
namespace SopApi.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TestRepository(DataContext context,IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddTestAsync(TestModel model)
        {
            var newTest = _mapper.Map<Test>(model);
            _context.Tests!.Add(newTest);
            await _context.SaveChangesAsync();
            return newTest.Id;

        }

        public async  Task DeletaTestAsync(int id)
        {
           var delTest = _context.Tests!.SingleOrDefault(b => b.Id == id);
           if(delTest != null)
            {
                _context.Tests!.Remove(delTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TestModel>> GetAllTestAsync()
        {
            var tests = await _context.Tests!.ToListAsync();
            return _mapper.Map<List<TestModel>>(tests);
        }

        public async Task<TestModel> GetTestAsync(int id)
        {
            var test = await _context.Tests!.FindAsync(id);
            return _mapper.Map<TestModel>(test);
        }

        public async Task UpdateTestAsync(int id, TestModel model)
        {
           if(id == model.Id)
            {
                var updateTest = _mapper.Map<Test>(model);
                _context.Tests!.Update(updateTest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
