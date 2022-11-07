using Business.Base;
using Entity.Entity;
using Entity.Model;

namespace Business.Services;

public interface IBlogService : IBaseService<Blog> {
    Task<List<Blog>> GetPaginationAsync(int page, int pageSize);
}
