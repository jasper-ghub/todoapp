﻿FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /ToDoApp
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /ToDoApp/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /ToDoApp
COPY --from=build-env /ToDoApp/out .
ENTRYPOINT ["dotnet", "ToDoApp.dll"]