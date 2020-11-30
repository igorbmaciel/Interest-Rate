FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY nuget.docker ./nuget.config
COPY InterestRate ./INTERESTRATE

WORKDIR /app/INTERESTRATE/src/InterestRate.Web
RUN dotnet restore
RUN dotnet publish -c Release -o /app/INTERESTRATE/out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/INTERESTRATE/out .
ENTRYPOINT ["dotnet", "InterestRate.Web.dll"]
