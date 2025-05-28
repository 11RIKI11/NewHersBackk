using System.Linq.Expressions;
using Core.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Utils;

/// <summary>
/// Вспомогательный класс для динамической сортировки коллекций
/// </summary>
public static class SortingHelper
{
    /// <summary>
    /// Применяет сортировку к запросу на основе списка запросов сортировки
    /// </summary>
    /// <typeparam name="T">Тип сущности для сортировки</typeparam>
    /// <param name="query">Исходный IQueryable</param>
    /// <param name="sortRequests">Список запросов сортировки</param>
    /// <returns>Отсортированный IQueryable</returns>
    public static IQueryable<T> ApplySorting<T>(IQueryable<T> query, IEnumerable<SortRequest> sortRequests)
    {
        if (sortRequests == null || !sortRequests.Any())
            return query;

        IOrderedQueryable<T> orderedQuery = null;

        foreach (var sort in sortRequests)
        {
            if (string.IsNullOrWhiteSpace(sort.SortBy))
                continue;

            // Проверяем, существует ли свойство в типе T
            var propertyInfo = typeof(T).GetProperties().FirstOrDefault(p => string.Equals(p.Name, sort.SortBy, StringComparison.OrdinalIgnoreCase));
            if (propertyInfo == null)
                continue;

            // Определяем направление сортировки (по умолчанию - по возрастанию)
            var isDescending = sort.SortDirection?.ToLower() == "desc";

            if (orderedQuery == null)
            {
                // Первая сортировка
                orderedQuery = isDescending
                    ? query.OrderByDescending(entity => EF.Property<object>(entity, propertyInfo.Name))
                    : query.OrderBy(entity => EF.Property<object>(entity, propertyInfo.Name));
            }
            else
            {
                // Дополнительная сортировка
                orderedQuery = isDescending
                    ? orderedQuery.ThenByDescending(entity => EF.Property<object>(entity, propertyInfo.Name))
                    : orderedQuery.ThenBy(entity => EF.Property<object>(entity, propertyInfo.Name));
            }
        }

        return orderedQuery ?? query;
    }

    /// <summary>
    /// Применяет сортировку к запросу на основе одного запроса сортировки
    /// </summary>
    /// <typeparam name="T">Тип сущности для сортировки</typeparam>
    /// <param name="query">Исходный IQueryable</param>
    /// <param name="sortRequest">Запрос сортировки</param>
    /// <returns>Отсортированный IQueryable</returns>
    public static IQueryable<T> ApplySorting<T>(IQueryable<T> query, SortRequest sortRequest)
    {
        if (sortRequest == null || string.IsNullOrWhiteSpace(sortRequest.SortBy))
            return query;

        return ApplySorting(query, new[] { sortRequest });
    }
}
