import { useState, useEffect } from 'react';
import { ThemeProvider, CssBaseline, Container, Box, Typography, Button, Snackbar, Alert } from '@mui/material';
import { Add as AddIcon } from '@mui/icons-material';
import { TopicsTable } from './components/TopicsTable';
import { TopicForm } from './components/TopicForm';
import { api } from './services/api';
import { theme } from './theme/theme';
import type { MathTopic } from './types/MathTopic';

interface SnackbarState {
  open: boolean;
  message: string;
  severity: 'success' | 'error';
}

function App() {
  const [topics, setTopics] = useState<MathTopic[]>([]);
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [selectedTopic, setSelectedTopic] = useState<MathTopic | undefined>();
  const [snackbar, setSnackbar] = useState<SnackbarState>({
    open: false,
    message: '',
    severity: 'success'
  });

  const fetchTopics = async () => {
    try {
      const data = await api.getTopics();
      setTopics(data);
    } catch (error) {
      showSnackbar('Failed to fetch topics', 'error');
    }
  };

  useEffect(() => {
    fetchTopics();
  }, []);

  const showSnackbar = (message: string, severity: 'success' | 'error') => {
    setSnackbar({ open: true, message, severity });
  };

  const handleCloseSnackbar = () => {
    setSnackbar({ ...snackbar, open: false });
  };

  const handleCreate = async (topicData: Partial<MathTopic>) => {
    try {
      if (!topicData.topic_name || !topicData.category || !topicData.sub_category || 
          !topicData.description || !topicData.difficulty_level) {
        throw new Error('Missing required fields');
      }
      
      const newTopic = {
        topic_name: topicData.topic_name,
        category: topicData.category,
        sub_category: topicData.sub_category,
        description: topicData.description,
        difficulty_level: topicData.difficulty_level
      };
      
      await api.createTopic(newTopic);
      showSnackbar('Topic created successfully', 'success');
      fetchTopics();
      setIsFormOpen(false);
    } catch (error) {
      showSnackbar('Failed to create topic', 'error');
    }
  };

  const handleUpdate = async (topicData: Partial<MathTopic>) => {
    try {
      if (!selectedTopic?.id || !topicData.topic_name || !topicData.category || 
          !topicData.sub_category || !topicData.description || !topicData.difficulty_level) {
        throw new Error('Missing required fields');
      }

      const updatedTopic: MathTopic = {
        ...selectedTopic,
        topic_name: topicData.topic_name,
        category: topicData.category,
        sub_category: topicData.sub_category,
        description: topicData.description,
        difficulty_level: topicData.difficulty_level
      };

      await api.updateTopic(updatedTopic.id, updatedTopic);
      showSnackbar('Topic updated successfully', 'success');
      fetchTopics();
      setIsFormOpen(false);
      setSelectedTopic(undefined);
    } catch (error) {
      showSnackbar('Failed to update topic', 'error');
    }
  };

  const handleDelete = async (id: number) => {
    if (window.confirm('Are you sure you want to delete this topic?')) {
      try {
        await api.deleteTopic(id);
        showSnackbar('Topic deleted successfully', 'success');
        fetchTopics();
      } catch (error) {
        showSnackbar('Failed to delete topic', 'error');
      }
    }
  };

  const handleEdit = (topic: MathTopic) => {
    setSelectedTopic(topic);
    setIsFormOpen(true);
  };

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container maxWidth="lg" sx={{ py: 4 }}>
        <Box sx={{ mb: 4, display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <Typography variant="h4" component="h1">
            Mathematics Topics
          </Typography>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={() => {
              setSelectedTopic(undefined);
              setIsFormOpen(true);
            }}
          >
            Add Topic
          </Button>
        </Box>

        <TopicsTable
          topics={topics}
          onEdit={handleEdit}
          onDelete={handleDelete}
        />

        <TopicForm
          open={isFormOpen}
          onClose={() => {
            setIsFormOpen(false);
            setSelectedTopic(undefined);
          }}
          onSubmit={selectedTopic ? handleUpdate : handleCreate}
          initialData={selectedTopic}
        />

        <Snackbar
          open={snackbar.open}
          autoHideDuration={6000}
          onClose={handleCloseSnackbar}
          anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
        >
          <Alert
            onClose={handleCloseSnackbar}
            severity={snackbar.severity}
            variant="filled"
            sx={{ width: '100%' }}
          >
            {snackbar.message}
          </Alert>
        </Snackbar>
      </Container>
    </ThemeProvider>
  );
}

export default App;
