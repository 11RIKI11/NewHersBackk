using AutoMapper;
using Core.Model.DTO;
using Core.Model.DTO.Auth;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class AuthService
{
    private readonly ApplicationDbContext _context;
    private readonly JwtTokenGenerator _jwtGenerator;
    private readonly IMapper _mapper;
    private readonly PasswordHasher _passwordHasher;

    public AuthService(ApplicationDbContext context, JwtTokenGenerator jwtGenerator, IMapper mapper,
        PasswordHasher passwordHasher)
    {
        _context = context;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<ServiceResult<(string token, string role, Guid id)>> RegisterAsync(RegisterRequest userRequest)
    {
        var userExist = await _context.Users.AnyAsync(u => u.Email == userRequest.Email);
        if (userExist)
            return ServiceResult<(string token, string role, Guid id)>.Failure("Email уже зарегистрирован", 409);

        var newUser = _mapper.Map<User>(userRequest);
        newUser.BirthDate = userRequest.BirthDate.ToUniversalTime();
        newUser.PasswordHash = _passwordHasher.HashPassword(userRequest.Password);

        await _context.AddAsync(newUser);
        await _context.SaveChangesAsync();

        var token = _jwtGenerator.GenerateToken(newUser.Id.ToString(), newUser.Email, newUser.Role);
        return ServiceResult<(string token, string role, Guid id)>.Success((token, newUser.Role, newUser.Id));
    }

    public async Task<ServiceResult<(string token, string role, Guid id)>> AuthenticateAsync(LoginRequest userData)
    {
        var user = await _context.Users
            .Where(u => u.Email == userData.Email)
            .FirstOrDefaultAsync();
        if (user == null)
            return ServiceResult<(string token, string role, Guid id)>.Failure("Пользователь не найден", 404);
        /*if (!_passwordHasher.VerifyPassword(userData.Password, user.PasswordHash))
        {
            return ServiceResult<(string token, string role, Guid id)>.Failure("Неверный пароль", 401);
        }*/
            

        var token = _jwtGenerator.GenerateToken(user.Id.ToString(), user.Email, user.Role);

        return ServiceResult<(string token, string role, Guid id)>.Success((token, user.Role, user.Id));
    }

    public async Task<ServiceResult<bool>> ChangePasswordAsync(Guid userId, ChangePasswordRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return ServiceResult<bool>.Failure("Пользователь не найден", 404);

        if (!_passwordHasher.VerifyPassword(request.OldPassword, user.PasswordHash))
            return ServiceResult<bool>.Failure("Неверный пароль", 401);

        user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }
}