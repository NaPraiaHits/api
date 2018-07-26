FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 59383
EXPOSE 44314

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SearchAPI/SearchAPI.csproj SearchAPI/
RUN dotnet restore SearchAPI/SearchAPI.csproj
COPY . .
WORKDIR /src/SearchAPI
RUN dotnet build SearchAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SearchAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SearchAPI.dll"]
