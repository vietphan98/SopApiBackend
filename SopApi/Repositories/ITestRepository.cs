using SopApi.Data;
using SopApi.Models;

namespace SopApi.Repositories
{
    public interface ITestRepository
    {
        public Task<List<TestModel>> GetAllTestAsync();
        public Task<TestModel> GetTestAsync(int id);
        public Task<int> AddTestAsync(TestModel model);
        public Task UpdateTestAsync(int id, TestModel model);
        public Task DeletaTestAsync(int id);
    }
}
