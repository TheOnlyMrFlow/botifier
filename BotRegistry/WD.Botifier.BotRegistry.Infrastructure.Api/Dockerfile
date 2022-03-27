FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api/WD.Botifier.BotRegistry.Infrastructure.Api.csproj", "WD.Botifier.BotRegistry.Infrastructure.Api/"]
RUN dotnet restore "BotRegistry/WD.Botifier.BotRegistry.Infrastructure.Api/WD.Botifier.BotRegistry.Infrastructure.Api.csproj"
COPY . .
WORKDIR "/src/WD.Botifier.BotRegistry.Infrastructure.Api"
RUN dotnet build "WD.Botifier.BotRegistry.Infrastructure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WD.Botifier.BotRegistry.Infrastructure.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WD.Botifier.BotRegistry.Infrastructure.Api.dll"]
