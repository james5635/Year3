## Manually run application

```sh
# for bash/zsh
export APP_ENV=<app_env>
export HOST=<host>
export PORT=<port>
export USER=<user>
export PASS=<password>
mysql -h${HOST} -P${PORT}  -u${USER} -p${PASS} < schema.sql
php -S localhost:8000 index.php
# open another shell
cd "Web UI"
export VITE_API_URL=http://localhost:8000
npm run build
php -S localhost:8080  -t dist
# visit http://localhost:8000 for API
# visit http://localhost:8080 for Web UI
```

```sh
# for powershell
$env:APP_ENV = "<app_env>"
$env:HOST = "<host>"
$env:PORT = "<port>"
$env:USER = "<user>"
$env:PASS = "<password>"
mysql -h$env:HOST -P$env:PORT -u$env:USER -p$env:PASS < schema.sql
php -S localhost:8000 index.php
# In a new PowerShell window
Set-Location "Web UI"
$env:VITE_API_URL = "http://localhost:8000"
npm run build
php -S localhost:8080 -t dist
# visit http://localhost:8000 for API
# visit http://localhost:8080 for Web UI
```

```sh
# for cmd.exe
set APP_ENV=<app_env>
set HOST=<host>
set PORT=<port>
set USER=<user>
set PASS=<password>
mysql -h%HOST% -P%PORT% -u%USER% -p%PASS% < schema.sql
php -S localhost:8000 index.php
REM In a new cmd window
cd "Web UI"
set VITE_API_URL=http://localhost:8000
npm run build
php -S localhost:8080 -t dist
REM visit http://localhost:8000 for API
REM visit http://localhost:8080 for Web UI
```

## Run with docker

```sh
export APP_ENV=<app_env>
export HOST=db
export PORT=<port>
export USER=root
export PASS=<password>
docker compose up --build
# visit http://localhost:8000 for API
# visit http://localhost:4173 for Web UI
```
