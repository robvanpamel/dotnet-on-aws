#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LookingOverTheHedge.Api/LookingOverTheHedge.Api.csproj", "LookingOverTheHedge.Api/"]
RUN dotnet restore "LookingOverTheHedge.Api/LookingOverTheHedge.Api.csproj"
COPY . .
WORKDIR "/src/LookingOverTheHedge.Api"
RUN dotnet build "LookingOverTheHedge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LookingOverTheHedge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LookingOverTheHedge.Api.dll"]