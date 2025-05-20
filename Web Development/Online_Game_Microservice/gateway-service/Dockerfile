FROM php:8.1-apache

RUN apt-get update && apt-get install -y \
    libzip-dev \
    libonig-dev \
    && docker-php-ext-install pdo_mysql mbstring zip

COPY --from=composer:latest /usr/bin/composer /usr/bin/composer

WORKDIR /var/www/html

# Copy your Slim app files
COPY . .

# Install PHP dependencies
RUN composer install --no-dev --optimize-autoloader

# Enable Apache rewrite module
RUN a2enmod rewrite

# Configure Apache vhost (optional, for production use usually Nginx or specific vhost config)
# For simplicity, we'll rely on .htaccess in public folder
COPY .htaccess /var/www/html/public/
RUN rm /var/www/html/index.html # Remove default apache index file if exists

EXPOSE 80