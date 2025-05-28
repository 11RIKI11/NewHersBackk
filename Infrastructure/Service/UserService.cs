using AutoMapper;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Auth;
using Core.Model.DTO.User;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

namespace Infrastructure.Service;

public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly JwtTokenGenerator _jwtGenerator;
    private readonly IMapper _mapper;
    private readonly PasswordHasher _passwordHasher;

    public UserService(ApplicationDbContext context, IMapper mapper, JwtTokenGenerator jwtTokenGenerator, PasswordHasher passwordHasher)
    {
        _context = context;
        _mapper = mapper;
        _jwtGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    // Получить пользователя по Id
    public async Task<ServiceResult<UserResponse>> GetUserByIdAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return ServiceResult<UserResponse>.Failure("Пользователь с таким Id не найден", 404);
        var mappedUser = _mapper.Map<UserResponse>(user);
        return ServiceResult<UserResponse>.Success(mappedUser);
    }

    // Получить список всех пользователей с пагинацией
    public async Task<ServiceResult<SearchResultResponse<UserResponse>>> GetUsersAsync(UserSearchRequest request)
    {
        var query = _context.Users.AsQueryable();

        if (request.Filter.UserIds.Count > 0)
            query = query.Where(a => request.Filter.UserIds.Contains(a.Id));

        if (!string.IsNullOrEmpty(request.Filter.FullName))
            query = query.Where(a =>
            EF.Functions.ILike(a.FullName, $"{request.Filter.FullName}%") ||
            EF.Functions.ILike(a.FullName, $" %{request.Filter.FullName}")
            );

        if (!string.IsNullOrEmpty(request.Filter.Email))
            query = query.Where(a => EF.Functions.ILike(a.Email, $"%{request.Filter.Email}%"));

        if(!string.IsNullOrEmpty(request.Filter.Phone))
            query = query.Where(a => EF.Functions.ILike(a.Phone, $"%{request.Filter.Phone}%"));

        if (request.Filter.Roles.Count > 0)
        {
            var roles = request.Filter.Roles.Select(r => r.ToString().ToLower()).ToList();
            query = query.Where(u => roles.Contains(u.Role));
        }

        if (request.Filter.CreatedAtFrom != null)
            query = query.Where(u => u.CreatedAt >= request.Filter.CreatedAtFrom);
        if(request.Filter.CreatedAtTo != null)
            query = query.Where(u => u.CreatedAt <= request.Filter.CreatedAtTo);

        if (request.Filter.BirthDateFrom != null)
            query = query.Where(u => u.BirthDate >= request.Filter.BirthDateFrom);
        if (request.Filter.BirthDateTo != null)
            query = query.Where(u => u.BirthDate <= request.Filter.BirthDateTo);

        query = SortingHelper.ApplySorting(query, request.Sort);

        var total = await query.CountAsync();

        // Пагинация
        var users = await query
            .Paginate(request.Pagination.Page, request.Pagination.PageSize)
            .ToListAsync();

        var mappingUsers = _mapper.Map<List<UserResponse>>(users);

        var result = new SearchResultResponse<UserResponse>
        {
            Items = mappingUsers,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<UserResponse>>.Success(result);
    }

    // Обновить данные пользователя
    public async Task<ServiceResult<bool>> UpdateUserAsync(Guid id, UserUpdateRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return ServiceResult<bool>.Failure("Пользователь с таким Id не найден", 404);

        _mapper.Map(request, user);

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    // Удалить пользователя
    public async Task<ServiceResult<bool>> DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return ServiceResult<bool>.Failure("Пользователь с таким Id не найден", 404);

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }
}
