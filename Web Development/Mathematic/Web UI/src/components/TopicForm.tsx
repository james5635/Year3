/**
 * Topic Form Component
 * 
 * This component provides a form for creating and editing math topics.
 * It renders a dialog with input fields for topic properties and handles form submission.
 */
import { useState, useEffect } from 'react';
import { TextField, Button, Dialog, DialogTitle, DialogContent, DialogActions, MenuItem, Box } from '@mui/material';
import type { MathTopic, DifficultyLevel } from '../types/MathTopic';

interface TopicFormProps {
    open: boolean;
    onClose: () => void;
    onSubmit: (topic: Partial<MathTopic>) => void;
    initialData?: MathTopic;
}

const DIFFICULTY_LEVELS: DifficultyLevel[] = ['Beginner', 'Intermediate', 'Advanced'];

export const TopicForm = ({ open, onClose, onSubmit, initialData }: TopicFormProps) => {
    const [formData, setFormData] = useState<Partial<MathTopic>>({
        topic_name: '',
        category: '',
        sub_category: '',
        description: '',
        difficulty_level: 'Beginner',
    });

    useEffect(() => {
        if (initialData) {
            setFormData(initialData);
        }
    }, [initialData]);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSubmit(formData);
        if (!initialData) {
            setFormData({
                topic_name: '',
                category: '',
                sub_category: '',
                description: '',
                difficulty_level: 'Beginner',
            });
        }
    };

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>{initialData ? 'Edit Topic' : 'Create New Topic'}</DialogTitle>
            <form onSubmit={handleSubmit}>
                <DialogContent>
                    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2 }}>
                        <TextField
                            label="Topic Name"
                            value={formData.topic_name}
                            onChange={(e) => setFormData({ ...formData, topic_name: e.target.value })}
                            required
                            fullWidth
                        />
                        <TextField
                            label="Category"
                            value={formData.category}
                            onChange={(e) => setFormData({ ...formData, category: e.target.value })}
                            required
                            fullWidth
                        />
                        <TextField
                            label="Sub Category"
                            value={formData.sub_category}
                            onChange={(e) => setFormData({ ...formData, sub_category: e.target.value })}
                            required
                            fullWidth
                        />
                        <TextField
                            label="Description"
                            value={formData.description}
                            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                            required
                            multiline
                            rows={4}
                            fullWidth
                        />
                        <TextField
                            select
                            label="Difficulty Level"
                            value={formData.difficulty_level}
                            onChange={(e) => setFormData({ ...formData, difficulty_level: e.target.value as DifficultyLevel })}
                            required
                            fullWidth
                        >
                            {DIFFICULTY_LEVELS.map((level) => (
                                <MenuItem key={level} value={level}>
                                    {level}
                                </MenuItem>
                            ))}
                        </TextField>
                    </Box>
                </DialogContent>
                <DialogActions>
                    <Button onClick={onClose}>Cancel</Button>
                    <Button type="submit" variant="contained" color="primary">
                        {initialData ? 'Update' : 'Create'}
                    </Button>
                </DialogActions>
            </form>
        </Dialog>
    );
};