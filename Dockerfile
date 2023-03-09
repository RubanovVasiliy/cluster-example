FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY . /src/
WORKDIR "/src/virtualization"
RUN dotnet build "virtualization.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "virtualization.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN adduser --disabled-password user

USER user

ENTRYPOINT ["dotnet", "virtualization.dll"]
