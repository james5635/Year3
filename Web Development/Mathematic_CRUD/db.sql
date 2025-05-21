DROP DATABASE IF EXISTS Math;
CREATE DATABASE Math;
USE Math;

CREATE TABLE MathTopics (
    id INT PRIMARY KEY AUTO_INCREMENT,
    topic_name VARCHAR(100),      -- e.g., Definite Integrals
    category VARCHAR(100),        -- e.g., Calculus
    sub_category VARCHAR(100),    -- e.g., Integral Calculus
    description TEXT,
    difficulty_level ENUM('Beginner', 'Intermediate', 'Advanced'),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

SELECT 'Successfully created table' AS '** Debug **';

INSERT INTO MathTopics (category, sub_category, topic_name, description, difficulty_level)
VALUES 
-- Algebra
('Algebra', 'Linear Algebra', 'Matrix Multiplication', 'Process of multiplying two matrices together', 'Intermediate'),
('Algebra', 'Linear Algebra', 'Eigenvalues and Eigenvectors', 'Special numbers and vectors for a matrix transformation', 'Advanced'),
('Algebra', 'Elementary Algebra', 'Linear Equations', 'Solving equations of the form ax + b = 0', 'Beginner'),
('Algebra', 'Elementary Algebra', 'Quadratic Equations', 'Solving second-degree polynomial equations', 'Intermediate'),
('Algebra', 'Abstract Algebra', 'Groups', 'A set with a binary operation satisfying group properties', 'Advanced'),

-- Calculus
('Calculus', 'Differential Calculus', 'Derivatives', 'Measuring the rate of change of a function', 'Intermediate'),
('Calculus', 'Differential Calculus', 'Chain Rule', 'Differentiating composite functions', 'Intermediate'),
('Calculus', 'Integral Calculus', 'Definite Integrals', 'Computing area under a curve over an interval', 'Intermediate'),
('Calculus', 'Integral Calculus', 'Indefinite Integrals', 'Finding antiderivatives of functions', 'Intermediate'),
('Calculus', 'Multivariable Calculus', 'Partial Derivatives', 'Derivatives of multivariable functions with respect to one variable', 'Advanced'),

-- Trigonometry
('Trigonometry', 'Basic Trigonometry', 'Trigonometric Ratios', 'Ratios of sides in a right triangle (sin, cos, tan)', 'Beginner'),
('Trigonometry', 'Advanced Trigonometry', 'Unit Circle', 'Defines trigonometric functions using a circle of radius 1', 'Intermediate'),
('Trigonometry', 'Trigonometric Identities', 'Pythagorean Identity', 'Identity: sin²θ + cos²θ = 1', 'Intermediate'),

-- Statistics
('Statistics', 'Descriptive Statistics', 'Mean, Median, Mode', 'Measures of central tendency', 'Beginner'),
('Statistics', 'Inferential Statistics', 'Confidence Intervals', 'Range of values likely to contain a population parameter', 'Intermediate'),
('Statistics', 'Probability Theory', 'Bayes Theorem', 'Describes probability of an event based on prior knowledge', 'Advanced'),

-- Discrete Math
('Discrete Math', 'Set Theory', 'Venn Diagrams', 'Visual tool for representing set relationships', 'Beginner'),
('Discrete Math', 'Combinatorics', 'Permutations and Combinations', 'Counting arrangements and selections', 'Intermediate'),
('Discrete Math', 'Graph Theory', 'Eulerian Paths', 'Paths that visit every edge exactly once', 'Advanced'),

-- Number Theory
('Number Theory', 'Prime Numbers', 'Greatest Common Divisor', 'The largest integer that divides two numbers', 'Beginner');

SELECT 'Successfully inserted data into table' AS '** Debug **';
