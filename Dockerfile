FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy of csproj and restore  as distinct layers
COPY *.sln .
COPY ./src/SeoulAir.Analytics.Api/*.csproj ./src/SeoulAir.Analytics.Api/
COPY ./src/SeoulAir.Analytics.Domain/*.csproj ./src/SeoulAir.Analytics.Domain/
COPY ./src/SeoulAir.Analytics.Domain.Services/*.csproj ./src/SeoulAir.Analytics.Domain.Services/
COPY ./src/SeoulAir.Analytics.Repositories/*.csproj ./src/SeoulAir.Analytics.Repositories/

RUN dotnet restore

# copy everything else and build app
COPY *.sln .
COPY ./src/SeoulAir.Analytics.Api/. ./src/SeoulAir.Analytics.Api/
COPY ./src/SeoulAir.Analytics.Domain/. ./src/SeoulAir.Analytics.Domain/
COPY ./src/SeoulAir.Analytics.Domain.Services/. ./src/SeoulAir.Analytics.Domain.Services/
COPY ./src/SeoulAir.Analytics.Repositories/. ./src/SeoulAir.Analytics.Repositories/

WORKDIR /app/src/SeoulAir.Analytics.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/src/SeoulAir.Analytics.Api/out ./
ENV ASPNETCORE_URLS=http://+:5700
ENTRYPOINT ["dotnet","SeoulAir.Analytics.Api.dll"]