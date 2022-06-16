# dotnet pack -c  release --no-restore 

$folders = Get-ChildItem -Path .\src -Directory | select Name

foreach($folder in $folders)
{
    $f = "src\$($folder.Name)\src\$($folder.Name)\bin\Release\$($folder.Name).1.0.0.nupkg"

    Write-Host $f

    #   dotnet pack $f release --no-restore  .

    # dotnet pack -c release D\:PackageVersion=1.0..0 --no-restore -o .
    dotnet nuget push -s http://192.168.1.109:5555/v3/index.json $f -k testapikey
}