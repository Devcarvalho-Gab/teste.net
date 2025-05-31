
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src


COPY "PackagingAPI.csproj" ./  
RUN dotnet restore "PackagingAPI.csproj"


COPY . . 
WORKDIR "/src"
RUN dotnet build "PackagingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PackagingAPI.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .   
ENTRYPOINT ["dotnet", "PackagingAPI.dll"]
