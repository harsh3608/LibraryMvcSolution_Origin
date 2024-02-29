#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LibraryMvc.UI/LibraryMvc.UI.csproj", "LibraryMvc.UI/"]
COPY ["LibraryMvc.Services/LibraryMvc.Services.csproj", "LibraryMvc.Services/"]
COPY ["LibraryMvc.Infrastructure/LibraryMvc.Infrastructure.csproj", "LibraryMvc.Infrastructure/"]
COPY ["LibraryMvc.Core/LibraryMvc.Core.csproj", "LibraryMvc.Core/"]
RUN dotnet restore "./LibraryMvc.UI/LibraryMvc.UI.csproj"
COPY . .
WORKDIR "/src/LibraryMvc.UI"
RUN dotnet build "./LibraryMvc.UI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LibraryMvc.UI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryMvc.UI.dll"]