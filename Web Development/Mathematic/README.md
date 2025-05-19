## Manually run application
```sh
# for bash/zsh
export APP_ENV=<app_env>
export HOST=<host>
export PORT=<port>
export DB_NAME=<dbname>
export USER=<user>
export PASS=<password>
mysql -h${HOST} -P${PORT}  -u${USER} -p${PASS} < schema.sql
php -S localhost:8000 index.php
```

```sh
docker run -p 3306:3306 -e MYSQL_ROOT_PASSWORD=james@2025 -d mysql

```