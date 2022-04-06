FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedditBotRunner/WD.Botifier.RedditBotRunner.Worker.Worker/WD.Botifier.RedditBotRunner.Worker.Worker.csproj", "WD.Botifier.RedditBotRunner.Worker.Worker/"]
RUN dotnet restore "RedditBotRunner/WD.Botifier.RedditBotRunner.Worker.Worker/WD.Botifier.RedditBotRunner.Worker.Worker.csproj"
COPY . .
WORKDIR "/src/WD.Botifier.RedditBotRunner.Worker.Worker"
RUN dotnet build "WD.Botifier.RedditBotRunner.Worker.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WD.Botifier.RedditBotRunner.Worker.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WD.Botifier.RedditBotRunner.Worker.Worker.dll"]
