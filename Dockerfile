#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY src/TC.GrupoTrinta.BlogNews.Api/*.csproj ./src/TC.GrupoTrinta.BlogNews.Api/
COPY src/TC.GrupoTrinta.BlogNews.Application/*.csproj ./src/TC.GrupoTrinta.BlogNews.Application/
COPY src/TC.GrupoTrinta.BlogNews.Domain/*.csproj ./src/TC.GrupoTrinta.BlogNews.Domain/
COPY src/TC.GrupoTrinta.BlogNews.Infra.Data.EF/*.csproj ./src/TC.GrupoTrinta.BlogNews.Infra.Data.EF/
COPY src/TC.GrupoTrinta.BlogNews.Infra.Identity/*.csproj ./src/TC.GrupoTrinta.BlogNews.Infra.Identity/
COPY src/TC.GrupoTrinta.BlogNews.Api.Tests/*.csproj ./src/TC.GrupoTrinta.BlogNews.Api.Tests/
COPY TC.GrupoTrinta.BlogNews.Api.Integration/*.csproj ./src/TC.GrupoTrinta.BlogNews.Api.Integration/


RUN dotnet restore ./src/TC.GrupoTrinta.BlogNews.Api/TC.GrupoTrinta.BlogNews.Api.csproj


COPY src ./src

RUN dotnet publish ./src/TC.GrupoTrinta.BlogNews.Api/TC.GrupoTrinta.BlogNews.Api.csproj -c Release -o /publish


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

# ENV ASPNETCORE_URLS="http://*:5000"

# Expose ports
EXPOSE 80
EXPOSE 443
#EXPOSE 5000


# Setup your variables before running.
ARG Development
ENV ASPNETCORE_ENVENTRYPOINT $Development

ENTRYPOINT ["dotnet", "TC.GrupoTrinta.BlogNews.Api.dll"]
