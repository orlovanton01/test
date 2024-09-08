FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Server

# Копировать всё
COPY . ./
# Создать слой образа
RUN dotnet restore Server.generated.sln
# Создать и опубликовать релиз
RUN dotnet publish Server.generated.sln -c Release -o out

# Открыть порт
EXPOSE 8888

# Создать образа среды выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Server
COPY --from=build-env /Server/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]