FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Loyihani tiklash (Restore)
COPY ["Task3/Task3.csproj", "Task3/"]
RUN dotnet restore "Task3/Task3.csproj"

# Kodni nusxalash va Build qilish
COPY . .
WORKDIR "/src/Task3"
RUN dotnet build "Task3.csproj" -c Release -o /app/build

# Publish qilish
FROM build AS publish
RUN dotnet publish "Task3.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final Runtime obraz
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task3.dll"]
