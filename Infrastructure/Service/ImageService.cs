using AutoMapper;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Image;
using Core.Model.Entities;
using Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class ImageService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public ImageService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<ServiceResult<ImageResponse>> AddUploadedImageAsync(ImageAddRequest imageAddRequest)
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        if (request == null)
            throw new Exception("Не удалось получить адрес сервера");
        var baseUrl = request != null ? $"{request.Scheme}://{request.Host}" : "";
        var extension = Path.GetExtension(imageAddRequest.Image.FileName);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageAddRequest.Image.CopyToAsync(stream);
        }
        var image = _mapper.Map<Core.Model.Entities.Image>(imageAddRequest);
        image.ImageUrl = $"{baseUrl}/images/{fileName}";

        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();

        var resultResponse = _mapper.Map<ImageResponse>(image);

        return ServiceResult<ImageResponse>.Success(resultResponse);
    }

    public async Task<ServiceResult<SearchResultResponse<ImageResponse>>> AddUploadedImagesAsync(List<ImageAddRequest> imagesAddRequest)
    {
        List<ImageResponse> resultResponse = new List<ImageResponse>();
        foreach (var image in imagesAddRequest)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new Exception("Не удалось получить адрес сервера");
            var baseUrl = request != null ? $"{request.Scheme}://{request.Host}" : "";
            var extension = Path.GetExtension(image.Image.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.Image.CopyToAsync(stream);
            }

            var entityImage = _mapper.Map<Image>(imagesAddRequest);

                entityImage.ImageUrl = $"{baseUrl}/images/{fileName}";

                await _context.Images.AddAsync(entityImage);
                await _context.SaveChangesAsync();

            resultResponse.Add(_mapper.Map<ImageResponse>(entityImage));
        };

        var result = new SearchResultResponse<ImageResponse>
        {
            Items = resultResponse,
            TotalCount = resultResponse.Count
        };

        return ServiceResult<SearchResultResponse<ImageResponse>>.Success(result);//TODO прокинь или похуй и то и то хуета))
    }

    public async Task<ServiceResult<bool>> RemoveImages(List<Guid> imageIds)
    {
        var images = await _context.Images
                .Where(im => imageIds.Contains(im.Id))
                .ToListAsync();
        if (images.Count == 0)
            return ServiceResult<bool>.Failure("Изображения не найдены", 404);

        foreach (var image in images)
        {
            var imageUrl = image.ImageUrl;
            var startIndex = imageUrl.IndexOf("images/") + "images/".Length;
            var fileName = imageUrl.Substring(startIndex);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        _context.Images.RemoveRange(images);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> RemoveImagesByEntityIdAsync(string entityId)
    {
        var images = await _context.Images
            .Where(im => im.EntityId == entityId)
            .ToListAsync();
        if (images.Count == 0)
            return ServiceResult<bool>.Failure("Изображения не найдены", 404);
        _context.RemoveRange(images);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<SearchResultResponse<ImageResponse>>> GetImagesByTypeAsync(string ImageType, PaginationRequest pagination)
    {
        var images = _context.Images.AsQueryable();
        images = images.Where(im => im.ImageType == ImageType);
        var total = await images.CountAsync();
        if (total == 0)
            return ServiceResult<SearchResultResponse<ImageResponse>>.Failure("Изображения не найдены", 404);
        var imagesList = await images
            .Paginate(pagination.Page, pagination.PageSize)
            .ToListAsync();

        var resultResponses = _mapper.Map<List<ImageResponse>>(imagesList);

        var result = new SearchResultResponse<ImageResponse>
        {
            Items = resultResponses,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<ImageResponse>>.Success(result);
    }
    public async Task<ServiceResult<SearchResultResponse<ImageResponse>>> GetImagesByEntityIdAsync(string entityId, PaginationRequest pagination)
    {
        var images = _context.Images.AsQueryable();
        images = images.Where(im => im.EntityId == entityId);
        var total = await images.CountAsync();
        if (total == 0)
            return ServiceResult<SearchResultResponse<ImageResponse>>.Failure("Изображения не найдены", 404);
        var imagesList = await images
            .Paginate(pagination.Page, pagination.PageSize)
            .ToListAsync();
        var resultResponses = _mapper.Map<List<ImageResponse>>(imagesList);

        var result = new SearchResultResponse<ImageResponse>
        {
            Items = resultResponses,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<ImageResponse>>.Success(result);
    }

    public async Task<ServiceResult<SearchResultResponse<ImageResponse>>> GetImagesByEntityTargetAsync(string entityTarget, PaginationRequest pagination)
    {
        var images = _context.Images.AsQueryable();
        images = images.Where(im => im.EntityTarget == entityTarget);
        var total = await images.CountAsync();
        if (total == 0)
            return ServiceResult<SearchResultResponse<ImageResponse>>.Failure("Изображения не найдены", 404);
        var imagesList = await images
            .Paginate(pagination.Page, pagination.PageSize)
            .ToListAsync();
        var resultResponses = _mapper.Map<List<ImageResponse>>(imagesList);

        var result = new SearchResultResponse<ImageResponse>
        {
            Items = resultResponses,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<ImageResponse>>.Success(result);
    }

    public async Task<ServiceResult<ImageResponse>> GetImageByIdAsync(Guid imageId)
    {
        var image = await _context.Images
            .FirstOrDefaultAsync(im => im.Id == imageId);
        if (image == null)
            return ServiceResult<ImageResponse>.Failure("Изображение не найдено", 404);
        var resultResponse = _mapper.Map<ImageResponse>(image);
        return ServiceResult<ImageResponse>.Success(resultResponse);
    }

    public async Task<ServiceResult<bool>> UpdateImageAsync(Guid imageId, ImageUpdateRequest updateRequest)
    {
        var image = await _context.Images
            .FirstOrDefaultAsync(im => im.Id == imageId);
        if (image == null)
            return ServiceResult<bool>.Failure("Изображение не найдено", 404);
        _mapper.Map(updateRequest, image);

        var request = _httpContextAccessor.HttpContext?.Request;
        if (request == null)
            throw new Exception("Не удалось получить адрес сервера");
        var baseUrl = request != null ? $"{request.Scheme}://{request.Host}" : "";
        var extension = Path.GetExtension(updateRequest.Image.FileName);
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await updateRequest.Image.CopyToAsync(stream);
        }
        image.ImageUrl = $"{baseUrl}/images/{fileName}";
        if (updateRequest.ImageType != null)
            image.ImageType = updateRequest.ImageType;
        image.LocalOrderRank = updateRequest.LocalOrderRank;
        image.EntityTarget = updateRequest.EntityTarget;
        image.EntityId = updateRequest.EntityId;
        _context.Images.Update(image);

        await _context.SaveChangesAsync();
        var resultResponse = _mapper.Map<ImageResponse>(image);


        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> RemoveImagesByTypeAsync (string imageType)
    {
        var images = await _context.Images
            .Where(im => im.ImageType == imageType)
            .ToListAsync();
        if (images.Count == 0)
            return ServiceResult<bool>.Failure("Изображения не найдены", 404);
        _context.RemoveRange(images);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> UpdateImagesByTypeAsync (string imageType, ImageUpdateRequest updateRequest)
    {
        var images = await _context.Images
            .Where(im => im.ImageType == imageType)
            .ToListAsync();
        if (images.Count == 0)
            return ServiceResult<bool>.Failure("Изображения не найдены", 404);
        foreach (var image in images)
        {
            _mapper.Map(updateRequest, image);
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
                throw new Exception("Не удалось получить адрес сервера");
            var baseUrl = request != null ? $"{request.Scheme}://{request.Host}" : "";
            var extension = Path.GetExtension(updateRequest.Image.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await updateRequest.Image.CopyToAsync(stream);
            }
            image.ImageUrl = $"{baseUrl}/images/{fileName}";
            if(updateRequest.ImageType != null)
                image.ImageType = updateRequest.ImageType;
            image.LocalOrderRank = updateRequest.LocalOrderRank;
            image.EntityTarget = updateRequest.EntityTarget;
            image.EntityId = updateRequest.EntityId;
            _context.Images.Update(image);
        }
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }
}

