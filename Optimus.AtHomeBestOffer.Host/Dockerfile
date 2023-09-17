#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Optimus.AtHomeBestOffer.Host/Optimus.AtHomeBestOffer.Host.csproj", "Optimus.AtHomeBestOffer.Host/"]
COPY ["Optimus.AtHomeBestOffer.Application/Optimus.AtHomeBestOffer.Application.csproj", "Optimus.AtHomeBestOffer.Application/"]
RUN dotnet restore "Optimus.AtHomeBestOffer.Host/Optimus.AtHomeBestOffer.Host.csproj"
COPY . .
WORKDIR "/src/Optimus.AtHomeBestOffer.Host"
RUN dotnet build "Optimus.AtHomeBestOffer.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Optimus.AtHomeBestOffer.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Optimus.AtHomeBestOffer.Host.dll"]