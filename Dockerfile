
from mcr.microsoft.com/dotnet/sdk:6.0 as build

workdir /app

copy *.sln ./
copy Project0Api/*.csproj Project0Api/
copy ProjectBL/*.csproj ProjectBL/
copy ProjectDL/*.csproj ProjectDL/
copy ProjectModel/*.csproj ProjectModel/
copy Project0Test/*.csproj Project0Test/

copy . ./

run dotnet publish -c Release -o publish

from mcr.microsoft.com/dotnet/sdk:6.0 as runtime

workdir /app

copy --from=build app/publish ./

cmd ["dotnet", "Project0Api.dll"]

expose 80