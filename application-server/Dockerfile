FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY ApplicationServer.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet build --configuration Release --output /app/build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "ApplicationServer.dll"]

