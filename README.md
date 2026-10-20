# ClinicBook API (starter)

This is your starting point for the ClinicBook capstone. You will grow it across the program:

| Milestone | Tag | Deadline (Kigali time) | What you add |
|---|---|---|---|
| M1 | `m1` | Sun 18 Oct, 23:59 | Doctors CRUD, in memory |
| M2 | `m2` | Wed 21 Oct, 23:59 | EF Core + SQLite, validation, paging, appointments with booking rules |
| M3 | `m3` | Sun 25 Oct, 23:59 | Register/login, JWT, Admin vs Patient roles, ownership, integration tests, one extension |
| Final | `final` | Mon 26 Oct, 12:30 | M3 plus polish, README, extension |

The tag must be pushed before the deadline. The grader checks out the tag, not your latest commit.

The contract you build to is `04-capstone/api-contract.md` in the kit. Read it before you write code. The acceptance tests check exactly what it says.

## What is already here

```
ClinicBook.slnx
ClinicBook.Api/
  ClinicBook.Api.csproj        .NET 10, OpenAPI + Scalar
  Program.cs                   controllers, JSON string enums, OpenAPI, Scalar
  Properties/launchSettings.json   http://localhost:5080
  ClinicBook.http              sample M1 calls
  Controllers/  Models/  Dtos/ empty folders for your code
.gitignore
README.md                      this file (replace it with your own at M3)
```

## Required repo layout

The grader looks for exactly these paths. Do not rename or move them.

```
your-repo/
  ClinicBook.Api/ClinicBook.Api.csproj
  ClinicBook.Tests/ClinicBook.Tests.csproj      (from M3)
  README.md
```

Create the test project at M3 from the repo root:

```bash
dotnet new xunit -n ClinicBook.Tests
dotnet sln ClinicBook.slnx add ClinicBook.Tests/ClinicBook.Tests.csproj
dotnet add ClinicBook.Tests reference ClinicBook.Api
```

## Run the API

From the repo root:

```bash
dotnet run --project ClinicBook.Api
```

Then open:

- Scalar UI: http://localhost:5080/scalar
- OpenAPI document: http://localhost:5080/openapi/v1.json

You can also open `ClinicBook.Api/ClinicBook.http` in Visual Studio, VS Code (REST Client) or Rider and send the sample requests.

The grader starts your API like this, after deleting every `*.db` file:

```bash
dotnet run --project ClinicBook.Api --urls http://localhost:5080
```

So from M2 on, your API must create its database and seed its data on startup.

## Run the acceptance tests

The tests live in the kit, not in your repo. You need Node.js 22. Keep your API running in one terminal, then in a second terminal go to the kit folder `04-capstone/acceptance-tests`:

macOS / Linux (bash, zsh):

```bash
cd 04-capstone/acceptance-tests
MILESTONE=1 npm test
```

Windows (PowerShell):

```powershell
cd 04-capstone/acceptance-tests
$env:MILESTONE=1; npm test
```

Change `MILESTONE` to `2` or `3` as you progress. The summary line at the end shows `Passed X / Y`. Each failing test name tells you which rule is broken, for example `[M2] POST /api/appointments returns 409 when the slot is taken`.

Tips:

- Restart the API after every code change before you rerun the tests.
- From M2, delete your `*.db` file when you change your models, so the database is recreated.
- If you choose extension E3 (rate limiting on login), wait one minute between test runs.

## Submit a milestone (Git tags)

Each milestone is a Git tag pushed to your GitHub repo. The grader checks out the tag, not your latest commit.

```bash
git add .
git commit -m "M1: doctors CRUD in memory"
git push
git tag m1 && git push origin m1
```

Use `m1`, `m2`, `m3` and `final`. Tags must be pushed before the deadline.

Made a mistake after tagging? Move the tag (only before the deadline):

```bash
git tag -d m1
git push origin :refs/tags/m1
git tag m1 && git push origin m1
```

## Checklist before you tag

- [ ] `dotnet build` has no errors
- [ ] API starts with `dotnet run --project ClinicBook.Api --urls http://localhost:5080` from a clean clone
- [ ] Acceptance tests pass for your milestone
- [ ] No `bin/`, `obj/` or `*.db` files committed
- [ ] (M3) `dotnet test` passes and your README explains how you used AI tools

---

Copyright © 2026 Francois Mugorozi @ francoismugorozi@gmail.com
