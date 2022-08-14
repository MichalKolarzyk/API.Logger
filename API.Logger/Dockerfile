#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API.Logger/API.Logger.csproj", "API.Logger/"]
RUN dotnet restore "API.Logger/API.Logger.csproj"
COPY . .
WORKDIR "/src/API.Logger"
RUN dotnet build "API.Logger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Logger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Logger.dll"]

#docker build -t api_logger -f Api.Logger/Dockerfile .
#docker run -d -e MONGODB_URL=mongodb://host.docker.internal:27017 -p 8080:80 --name api_logger_app api_logger