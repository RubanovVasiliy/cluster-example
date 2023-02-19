# Используем более легкий базовый образ
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . /src/
WORKDIR "/src/virtualization"
RUN dotnet build "virtualization.csproj" -c Release -o /app/build

# Используем многоэтапную сборку
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "virtualization.dll"]