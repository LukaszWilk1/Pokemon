# Etap buildowania
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopiuj csproj i przywróć zależności
COPY *.csproj ./
RUN dotnet restore

# Kopiuj pozostałe pliki i opublikuj
COPY . ./
RUN dotnet publish -c Release -o out

# Etap runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
ENTRYPOINT ["dotnet", "Pokemon.dll"]
