# Update both base and SDK images to 8.0
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["webAPI.csproj", "./"]
RUN dotnet restore "./webAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "webAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webAPI.dll"]