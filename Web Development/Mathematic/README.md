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
```
## Run with docker
```sh
export APP_ENV=<app_env>
export HOST=db
export PORT=<port>
export USER=root
export PASS=<password>
docker compose up --build
```