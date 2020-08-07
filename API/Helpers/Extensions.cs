using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int totalPages, int itemsPerPage, int totalItems)
        {
            PaginationHeader paginationHeader = new PaginationHeader(currentPage, totalPages, itemsPerPage, totalItems);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, settings));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}