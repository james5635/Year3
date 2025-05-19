import axios from 'axios';
import type { MathTopic } from '../types/MathTopic';

const API_URL = 'http://localhost:8000';

interface ApiResponse {
    message: string;
}

export const api = {
    getTopics: async () => {
        try {
            const response = await axios.get<MathTopic[]>(API_URL);
            return response.data;
        } catch (error) {
            console.error('Error fetching topics:', error);
            throw new Error('Failed to fetch topics');
        }
    },

    getTopic: async (id: number) => {
        try {
            const response = await axios.get<MathTopic>(`${API_URL}?id=${id}`);
            if ('message' in response.data) {
                throw new Error(response.data.message);
            }
            return response.data;
        } catch (error) {
            console.error('Error fetching topic:', error);
            throw error;
        }
    },

    createTopic: async (topic: Omit<MathTopic, 'id'>) => {
        try {
            const response = await axios.post<ApiResponse>(API_URL, topic);
            return response.data;
        } catch (error) {
            console.error('Error creating topic:', error);
            throw new Error('Failed to create topic');
        }
    },

    updateTopic: async (id: number, topic: Partial<MathTopic>) => {
        try {
            const response = await axios.put<ApiResponse>(`${API_URL}?id=${id}`, topic);
            return response.data;
        } catch (error) {
            console.error('Error updating topic:', error);
            throw new Error('Failed to update topic');
        }
    },

    deleteTopic: async (id: number) => {
        try {
            const response = await axios.delete<ApiResponse>(`${API_URL}?id=${id}`);
            return response.data;
        } catch (error) {
            console.error('Error deleting topic:', error);
            throw new Error('Failed to delete topic');
        }
    }
};