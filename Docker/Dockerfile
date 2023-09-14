# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Technical Interview Exercise V2/Technical Interview Exercise V2.csproj", "Technical Interview Exercise V2/"]
RUN dotnet restore "Technical Interview Exercise V2/Technical Interview Exercise V2.csproj"
COPY . .
WORKDIR "/src/Technical Interview Exercise V2"
RUN dotnet build "Technical Interview Exercise V2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Technical Interview Exercise V2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Technical Interview Exercise V2.dll"]
