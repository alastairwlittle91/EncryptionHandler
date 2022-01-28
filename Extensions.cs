using Microsoft.Extensions.DependencyInjection;

namespace EncryptionHandler;
public static class Extensions 
{
    public static IServiceCollection AddEncryptionService(this IServiceCollection services, string encryptionKey) 
   {
       services.AddTransient<IEncryptionService>(o => {
                return new EncryptionService(encryptionKey);
            });
       return services;

   }
}