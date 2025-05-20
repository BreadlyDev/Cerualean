namespace Infrastructure.Pagination;

public class PaginationDefaults
{
    public static int DefaultPage { get; private set; }
    public static int DefaultPageSize { get; private set; }

    public static void Configure(PaginationOptions options)
    {
        DefaultPage = options.DefaultPage;
        DefaultPageSize = options.DefaultPageSize;
    }
}

