FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Imobiliaria/Imobiliaria.csproj", "Imobiliaria/"]
RUN dotnet restore "Imobiliaria/Imobiliaria.csproj"
COPY . .
WORKDIR "/src/Imobiliaria"
RUN dotnet build "Imobiliaria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Imobiliaria.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Imobiliaria.dll"]
