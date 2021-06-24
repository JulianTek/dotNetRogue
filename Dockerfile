#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY ["dotNetRogue.Presentation/dotNetRogue.Presentation.csproj", "dotNetRogue.Presentation/"]
COPY ["dotNetRogue.Application/dotNetRogue.Application.csproj", "dotNetRogue.Application/"]
COPY ["dotNetRogue.Domain/dotNetRogue.Domain.csproj", "dotNetRogue.Domain/"]
COPY ["dotNetRogue.Persistence/dotNetRogue.Persistence.csproj", "dotNetRogue.Persistence/"]
RUN dotnet restore "dotNetRogue.Presentation/dotNetRogue.Presentation.csproj"
COPY . .
WORKDIR "/src/dotNetRogue.Presentation"
RUN dotnet build "dotNetRogue.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotNetRogue.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotNetRogue.Presentation.dll"]