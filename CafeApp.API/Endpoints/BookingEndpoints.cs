using CafeApp.Application.Bookings;

namespace CafeApp.API.Endpoints;

public static class BookingEndpoints
{
    public static IEndpointRouteBuilder MapBookingEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/bookings")
            .WithTags("Bookings");
        
        group.MapPost("/",CreateBooking);

        //group.MapGet(
        //    "/{id:int}",
        //    GetBooking);

        return group;
    }

    private static async Task<IResult> CreateBooking(
        CreateBookingCommand command,
        CreateBookingHandler handler,
        CancellationToken ct)
    {
        var id = await handler.HandleAsync(command,ct);

        return Results.Created(
            $"/bookings/{id}",
            id);
    }

    //private static async Task<IResult> GetBooking(
    //    int id,
    //    IBookingQueryService service,
    //    CancellationToken ct)
    //{
    //    var booking = await service.GetAsync(
    //        id,
    //        ct);

    //    return booking is null
    //        ? Results.NotFound()
    //        : Results.Ok(booking);
    //}
}