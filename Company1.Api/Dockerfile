#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Company1.Api/Company1.Api.csproj", "Company1.Api/"]
RUN dotnet restore "Company1.Api/Company1.Api.csproj"
COPY . .
WORKDIR "/src/Company1.Api"
RUN dotnet build "Company1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company1.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company1.Api.dll"]