﻿using HeavyService.Service.Commons.Securities;
using Microsoft.Extensions.Caching.Memory;
using UpSkills.Applications.Exceptions;
using UpSkills.Applications.Exceptions.Auth;
using UpSkills.Applications.Exceptions.Users;
using UpSkills.DataAccess.Interfaces.Users;
using UpSkills.Domain.Entities.Users;
using UpSkills.Domain.Enums;
using UpSkills.Persistance.Dto.Auth;
using UpSkills.Persistance.Dto.Notifications;
using UpSkills.Persistance.Dto.security;
using UpSkills.Persistance.Helpers;
using UpSkills.Service.Interfaces.Auth;
using UpSkills.Service.Interfaces.Commons;
using UpSkills.Service.Interfaces.Notifications;

namespace UpSkills.Service.Service.Auth;

public class AuthService : IAuthService
{
    private readonly IIdentityService _service;
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _repository;
    private readonly IEmailSMSSender _emailSender;
    private readonly ITokenService _tokenService;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;
    public AuthService(IMemoryCache memoryCache, IUserRepository userrepos,
        IEmailSMSSender emailSender, ITokenService tokenService, IIdentityService service)
    {
        this._memoryCache = memoryCache;
        this._repository = userrepos;
        this._emailSender = emailSender;
        this._tokenService = tokenService;
        this._service = service;
    }
    public async Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto)
    {
        var user = await _repository.GetByEmailAsync(loginDto.Email);
        if (user is null) throw new UserNotFoundException();
        var hasherResult = PasswordHasher.Verify(loginDto.Password, user.PasswordHash, user.Salt);
        if (hasherResult == false) throw new PasswordIncorrectException();
        string token = await _tokenService.GenerateToken(user);

        return (Result: true, Token: token);
    }
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistrDto dto)
    {
        var user = await _repository.GetByEmailAsync(dto.Email);
        if (user is not null) throw new UserAllReadyExistsException();
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out RegistrDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(dto.Email);
        }
        else
        {
            _memoryCache.Set(REGISTER_CACHE_KEY + dto.Email, dto, TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));
        }

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }
    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email)
    {
        var users = await _repository.GetByEmailAsync(email);
        if (users is not null) throw new UserAllReadyExistsException();
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out RegistrDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelpers.GetDateTime();
            verificationDto.Code = CodeGenerator.GenerateRandomNumber();
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto oldVerifcationDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + email);
            }
            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            SmsMessage emailMessage = new SmsMessage();
            emailMessage.Title = "Up Skills";
            emailMessage.Content = "Your verification code : " + verificationDto.Code;
            emailMessage.Resipient = email;
            var emailResult = await _emailSender.SendAsync(emailMessage);

            if (emailResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new EmailExpiredException();
    }
    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out RegistrDto registerDto))
        {
            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VaerificationTooManyRequestException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registerDto);
                    if (dbResult is true)
                    {
                        var user = await _repository.GetByEmailAsync(email);
                        string token = await _tokenService.GenerateToken(user);

                        return (Result: true, Token: token);
                    }

                    return (Result: dbResult, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + email);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                        TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

                    return (Result: false, Token: "");
                }
            }
            else throw new VaerificationTooManyRequestException();
        }
        else throw new EmailExpiredException();
    }
    private async Task<bool> RegisterToDatabaseAsync(RegistrDto registerDto)
    {
        var user = new User();
        user.FirstName = registerDto.FirstName;
        user.LastName = registerDto.LastName;
        user.Email = registerDto.Email;
        user.Status = UserStatusRoles.User;
        var hasherResult = PasswordHasher.Hash(registerDto.Password);
        user.PasswordHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;
        user.Amount = 100000;
        user.CreatedAt = user.UpdatedAt = TimeHelpers.GetDateTime();
        var dbResult = await _repository.CreateAsync(user);

        return dbResult > 0;
    }
}