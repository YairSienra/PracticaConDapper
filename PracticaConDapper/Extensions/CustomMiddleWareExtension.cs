namespace PracticaConDapper.Extensions
{
    public static class CustomMiddleWareExtension
    {
        public static  IApplicationBuilder UseSienraCustomMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
