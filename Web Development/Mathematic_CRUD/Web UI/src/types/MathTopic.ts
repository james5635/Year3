/**
 * Math Topic Type Definitions
 * 
 * This file defines TypeScript types and interfaces for mathematics topics
 * used throughout the application.
 */

export type DifficultyLevel = 'Beginner' | 'Intermediate' | 'Advanced';

export interface MathTopic {
    id: number;
    topic_name: string;
    category: string;
    sub_category: string;
    description: string;
    difficulty_level: DifficultyLevel;
    created_at?: string;
    updated_at?: string;
    is_active?: boolean;
}