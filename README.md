# graphql-dab

## Setup
### DAB
- Create an `.env` file in `dab` with the following: `COSMOSDB_CONNECTIONSTRING="PLACE_COSMOSDB_CONNECTIONSTRING_HERE"`
- run `dab start` in `dab`
- Verify it's working by navigating to `http://localhost:5000/graphql` and running a query to retrieve all conferences

### SWA CLI
- Copy the contents of `dab/dab-config.json` into `swa-db-connections/staticwebapp.database.config.json`
- Ensure you have the `dab/schema.gql` in `swa-db-connections` as well and that `staticwebapp.database.config.json` references it correctly.
- Ensure the `dataApiLocation` property is set to `swa-db-connections` in `swa-cli.config.json`
- Ensure that `mode` is set to `development` in `staticwebapp.database.config.json`
- run `swa start` in the root directory of your SWA project
- Verify it's working by navigating to `http://localhost:5000/graphql` and running a query to retrieve all conferences

### .NET
- in case you use SWA CLI to run DAB, change the url in `Program.cs` to `http://localhost:4280/data-api/graphql`
- run `dotnet watch run` in `client`
- You should see the amount of conferences and talks in your cosmosdb database in the terminal.

# Issues
I'm not quite happy with having to insert `ConferenceTalk` as an entity in `dab-config.json` in order to get the model to work. I've created the following GitHub issue for it: https://github.com/Azure/data-api-builder/issues/2335