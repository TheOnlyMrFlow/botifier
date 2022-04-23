FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WD.Botifier.SeedWork/WD.Botifier.SeedWork.csproj", "WD.Botifier.SeedWork/WD.Botifier.SeedWork.csproj"]
COPY ["WD.Botifier.SharedKernel/WD.Botifier.SharedKernel.csproj", "WD.Botifier.SharedKernel/WD.Botifier.SharedKernel.csproj"]
COPY ["Services/BotRegistry/WD.Botifier.BotRegistry.Domain/WD.Botifier.BotRegistry.Domain.csproj", "Services/BotRegistry/WD.Botifier.BotRegistry.Domain/WD.Botifier.BotRegistry.Domain.csproj"]
COPY ["Services/BotRegistry/WD.Botifier.BotRegistry.Application/WD.Botifier.BotRegistry.Application.csproj", "Services/BotRegistry/WD.Botifier.BotRegistry.Application/WD.Botifier.BotRegistry.Application.csproj"]
COPY ["Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb/WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.csproj", "Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb/WD.Botifier.BotRegistry.Infrastructure.Persistence.MongoDb.csproj"]
COPY ["Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api/WD.Botifier.BotRegistry.Infrastructure.Api.csproj", "Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api/WD.Botifier.BotRegistry.Infrastructure.Api.csproj"]
RUN dotnet restore "Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api/WD.Botifier.BotRegistry.Infrastructure.Api.csproj"
COPY . .
WORKDIR "/src/Services/BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api"
RUN dotnet build "WD.Botifier.BotRegistry.Infrastructure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WD.Botifier.BotRegistry.Infrastructure.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WD.Botifier.BotRegistry.Infrastructure.Api.dll"]
