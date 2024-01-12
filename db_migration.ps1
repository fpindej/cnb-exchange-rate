param(
    [string]$MigrationName = "DbMigration",
    [string]$ProjectPath = ".\src\Infrastructure.Persistence\Infrastructure.Persistence.csproj",
    [string]$StartupProjectPath = ".\src\WebApi\WebApi.csproj"
)

function ExecuteCommand {
    param(
        [string]$Command
    )

    try {
        Write-Host "Executing: $Command"
        Invoke-Expression $Command
        if ($LASTEXITCODE -ne 0) {
            throw "Command exited with code $LASTEXITCODE"
        }
    } catch {
        Write-Host "Error: $_"
        exit $LASTEXITCODE
    }
}

Write-Host "Starting migration: $MigrationName"

ExecuteCommand "dotnet ef migrations add $MigrationName --project $ProjectPath --startup-project $StartupProjectPath"

Write-Host "Migration $MigrationName added successfully."

Write-Host "Updating database with migration $MigrationName"

ExecuteCommand "dotnet ef database update  --project $ProjectPath --startup-project $StartupProjectPath"

Write-Host "Database updated successfully with migration $MigrationName."