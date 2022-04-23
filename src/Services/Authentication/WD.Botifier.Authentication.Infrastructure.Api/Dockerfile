FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WD.Botifier.SeedWork/WD.Botifier.SeedWork.csproj", "WD.Botifier.SeedWork/WD.Botifier.SeedWork.csproj"]
COPY ["WD.Botifier.SharedKernel/WD.Botifier.SharedKernel.csproj", "WD.Botifier.SharedKernel/WD.Botifier.SharedKernel.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Domain/WD.Botifier.Authentication.Domain.csproj", "Services/Authentication/WD.Botifier.Authentication.Domain/WD.Botifier.Authentication.Domain.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Application/WD.Botifier.Authentication.Application.csproj", "Services/Authentication/WD.Botifier.Authentication.Application/WD.Botifier.Authentication.Application.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Infrastructure.Jwt/WD.Botifier.Authentication.Infrastructure.Jwt.csproj", "Services/Authentication/WD.Botifier.Authentication.Infrastructure.Jwt/WD.Botifier.Authentication.Infrastructure.Jwt.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Infrastructure.PasswordEncryptor/WD.Botifier.Authentication.Infrastructure.PasswordEncryptor.csproj", "Services/Authentication/WD.Botifier.Authentication.Infrastructure.PasswordEncryptor/WD.Botifier.Authentication.Infrastructure.PasswordEncryptor.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb/WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb.csproj", "Services/Authentication/WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb/WD.Botifier.Authentication.Infrastructure.Persistence.MongoDb.csproj"]
COPY ["Services/Authentication/WD.Botifier.Authentication.Infrastructure.Api/WD.Botifier.Authentication.Infrastructure.Api.csproj", "Services/Authentication/WD.Botifier.Authentication.Infrastructure.Api/WD.Botifier.Authentication.Infrastructure.Api.csproj"]
RUN dotnet restore "Services/Authentication/WD.Botifier.Authentication.Infrastructure.Api/WD.Botifier.Authentication.Infrastructure.Api.csproj"
COPY . .
WORKDIR "/src/Services/Authentication/WD.Botifier.Authentication.Infrastructure.Api"
RUN dotnet build "WD.Botifier.Authentication.Infrastructure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WD.Botifier.Authentication.Infrastructure.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WD.Botifier.Authentication.Infrastructure.Api.dll"]
