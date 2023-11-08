#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WindParkService/WindParkService.csproj", "WindParkService/"]
RUN dotnet restore "WindParkService/WindParkService.csproj"
COPY . .
WORKDIR "/src/WindParkService"
RUN dotnet build "WindParkService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WindParkService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WindParkService.dll"]