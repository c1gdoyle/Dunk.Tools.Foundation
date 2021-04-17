#!/bin/sh

# Run Release build
echo "Running build..."
dotnet build /p:Configuration=Release ./Dunk.Tools.Foundation.sln

# Run Tests, Coverlet to record result and OpenCover code-coverage
echo "Running tests..."
dotnet test /p:Configuration=Release --no-build ./Dunk.Tools.Foundation.Test/Dunk.Tools.Foundation.Test.csproj --logger:trx /p:CollectCoverage=true /p:CoverletOutputFormat=opencover