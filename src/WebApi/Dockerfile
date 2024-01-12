FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LocalTestingApp.WebApi/LocalTestingApp.WebApi.csproj", "LocalTestingApp.WebApi/"]
RUN dotnet restore "LocalTestingApp.WebApi/LocalTestingApp.WebApi.csproj"
COPY . .
WORKDIR "/src/LocalTestingApp.WebApi"
RUN dotnet build "LocalTestingApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocalTestingApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalTestingApp.WebApi.dll"]
