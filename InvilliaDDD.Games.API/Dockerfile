#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["InvilliaDDD.Games.API/InvilliaDDD.GameManager.API.csproj", "InvilliaDDD.Games.API/"]
COPY ["InvilliaDDD.Data/InvilliaDDD.GameManager.Data.csproj", "InvilliaDDD.Data/"]
COPY ["InvilliaDDD.Games.Domain/InvilliaDDD.GameManager.Domain.csproj", "InvilliaDDD.Games.Domain/"]
COPY ["InvilliaDDD/InvilliaDDD.Core.csproj", "InvilliaDDD/"]
COPY ["InvilliaDDD.Games.Application/InvilliaDDD.GameManager.Application.csproj", "InvilliaDDD.Games.Application/"]
COPY ["InvilliaDDD.WebApi.Core/InvilliaDDD.WebApi.Core.csproj", "InvilliaDDD.WebApi.Core/"]
RUN dotnet restore "InvilliaDDD.Games.API/InvilliaDDD.GameManager.API.csproj"
COPY . .
WORKDIR "/src/InvilliaDDD.Games.API"
RUN dotnet build "InvilliaDDD.GameManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvilliaDDD.GameManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvilliaDDD.GameManager.API.dll"]