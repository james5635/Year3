FROM php:8-alpine

# Install required PHP extensions
RUN docker-php-ext-install pdo pdo_mysql

# Install Composer
COPY --from=composer:latest /usr/bin/composer /usr/bin/composer

# Set working directory
WORKDIR /app

# Copy only what you need (use .dockerignore!)
COPY . .

# Install PHP dependencies
RUN composer install --no-dev --optimize-autoloader

# Set command
CMD ["php", "-S", "0.0.0.0:8000", "index.php"]
