# Async Drone Dash

  Console simulator comparing manual thread coordination (`Thread` + `Join`) against modern `async`/`await` orchestration, using a drones as an example.

  ## Run

  dotnet run --project 1108.csproj
  >menu:
  Welcome to the Drone Race
  a) Del A - Thread Race (Thread + Join)
  b) Del B - Async orchestration (async/await + Task.WhenAll)
  >Choose:
  - **a** — runs the raw `Thread`/`Join` version (Alpha, Bravo).
  - **b** — runs the `async`/`Task.WhenAll` version with a live console board (Alpha, Bravo, Charlie — Charlie deliberately fails mid-flight to demonstrate exception
  propagation).

  >Run it twice, once per option, to see both.

  ## Tests
  dotnet test drone.Tests/drone.Tests.csproj
  Covers `DroneModel`'s input validation.

  ## Project structure
  - `drone/` — class library: `DroneModel`,  `ThreadRace/` (Del A), `AsyncFlow/` (Del B), `Presentation/` (the live console board).
  - `1108/` (repo root) — console app, entry point + menu.
  - `drone.Tests/` — xUnit tests.

  ## Reflection
  See `refleksjon.md` for observations from both parts.
