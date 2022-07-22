#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
#RUN dotnet restore "WebAPI/WebAPI.csproj"
#COPY . .
#WORKDIR "/src/WebAPI"
#RUN dotnet build "WebAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAPI.dll
##ENTRYPOINT ["dotnet", "WebAPI.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:6.0 AS build
COPY bin/Release/net6.0/publish/ app/
WORKDIR /app

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAPI.dll