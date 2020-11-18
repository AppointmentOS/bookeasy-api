FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Bookeasy.Api/Bookeasy.Api.csproj", "Bookeasy.Api/"]

RUN dotnet restore "Bookeasy.Api/Bookeasy.Api.csproj"
COPY . .
WORKDIR "/src/Bookeasy.Api"
RUN dotnet build "Bookeasy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookeasy.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookeasy.Api.dll"]