FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY nuget.docker ./nuget.config
COPY InterestCalculation ./INTERESTCALCULATION
COPY Services ./Services

WORKDIR /app/INTERESTCALCULATION/src/InterestCalculation.Web
RUN dotnet restore
RUN dotnet publish -c Release -o /app/INTERESTCALCULATION/out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/INTERESTCALCULATION/out .
ENTRYPOINT ["dotnet", "InterestCalculation.Web.dll"]
