FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["RepublicaEmpleos.WebApi/RepublicaEmpleos.WebApi.csproj", "RepublicaEmpleos.WebApi/"]
COPY ["RepublicaEmpleos.DTO/RepublicaEmpleos.Models.csproj", "RepublicaEmpleos.DTO/"]
COPY ["RepublicaEmpleos.Core/RepublicaEmpleos.Core.csproj", "RepublicaEmpleos.Core/"]
RUN dotnet restore "RepublicaEmpleos.WebApi/RepublicaEmpleos.WebApi.csproj"
COPY . .
WORKDIR "/src/RepublicaEmpleos.WebApi"
RUN dotnet build "RepublicaEmpleos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepublicaEmpleos.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepublicaEmpleos.WebApi.dll"]