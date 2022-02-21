# TimeKeeper

## Docker
- Run docker compose with database and webapi: `docker-compose -f .\scripts\web-api.yml -f .\scripts\sql-server.yml up --build`

## Database
- Update Database: `dotnet ef database update --project .\TimeKeeper.Persistence -- "Server=localhost,8000;Database=TimeKeeperAppDb;User Id=SA;Password=VerySecurePassword321;"`
