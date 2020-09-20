#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Blazor.ServerApp/Blazor.ServerApp.csproj", "Blazor.ServerApp/"]
COPY ["FrontEnd/Blazor.Server/Blazor.Server.csproj", "FrontEnd/Blazor.Server/"]
COPY ["FrontEnd/Blazor.ComponentsLibrary/Blazor.ComponentsLibrary.csproj", "FrontEnd/Blazor.ComponentsLibrary/"]
COPY ["FrontEnd/Blazor.Shared/Blazor.Shared.csproj", "FrontEnd/Blazor.Shared/"]
RUN dotnet restore "Blazor.ServerApp/Blazor.ServerApp.csproj"
COPY . .
WORKDIR "/src/Blazor.ServerApp"
RUN dotnet build "Blazor.ServerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blazor.ServerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blazor.ServerApp.dll"]