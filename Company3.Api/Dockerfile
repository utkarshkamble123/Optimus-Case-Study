#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Company3.Api/Company3.Api.csproj", "Company3.Api/"]
RUN dotnet restore "Company3.Api/Company3.Api.csproj"
COPY . .
WORKDIR "/src/Company3.Api"
RUN dotnet build "Company3.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Company3.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Company3.Api.dll"]