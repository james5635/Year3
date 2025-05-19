import { Paper, IconButton } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import type { GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { Edit as EditIcon, Delete as DeleteIcon } from '@mui/icons-material';
import type { MathTopic } from '../types/MathTopic';

interface TopicsTableProps {
  topics: MathTopic[];
  onEdit: (topic: MathTopic) => void;
  onDelete: (id: number) => void;
}

export const TopicsTable = ({ topics, onEdit, onDelete }: TopicsTableProps) => {
  const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'topic_name', headerName: 'Topic Name', flex: 1 },
    { field: 'category', headerName: 'Category', flex: 1 },
    { field: 'sub_category', headerName: 'Sub Category', flex: 1 },
    { 
      field: 'description', 
      headerName: 'Description', 
      flex: 1.5,
      renderCell: (params) => (
        <div style={{ whiteSpace: 'normal', wordWrap: 'break-word' }}>
          {params.value}
        </div>
      )
    },
    {
      field: 'difficulty_level',
      headerName: 'Difficulty',
      flex: 0.8,
      renderCell: (params: GridRenderCellParams) => {
        const color = {
          Beginner: '#4caf50',
          Intermediate: '#ff9800',
          Advanced: '#f44336'
        }[params.value as string] || '#757575';
        
        return (
          <div style={{
            backgroundColor: color,
            color: 'white',
            padding: '4px 8px',
            borderRadius: '4px',
            fontSize: '0.875rem'
          }}>
            {params.value}
          </div>
        );
      }
    },
    {
      field: 'actions',
      headerName: 'Actions',
      width: 120,
      sortable: false,
      renderCell: (params: GridRenderCellParams) => (
        <>
          <IconButton
            size="small"
            onClick={() => onEdit(params.row)}
            color="primary"
          >
            <EditIcon />
          </IconButton>
          <IconButton
            size="small"
            onClick={() => onDelete(params.row.id)}
            color="error"
          >
            <DeleteIcon />
          </IconButton>
        </>
      )
    }
  ];

  return (
    <Paper sx={{ width: '100%', overflow: 'hidden' }}>
      <DataGrid
        rows={topics}
        columns={columns}
        initialState={{
          pagination: {
            paginationModel: { page: 0, pageSize: 10 },
          },
        }}
        pageSizeOptions={[5, 10, 25]}
        autoHeight
        disableRowSelectionOnClick
        sx={{
          '& .MuiDataGrid-cell': {
            borderBottom: '1px solid #f0f0f0'
          },
          '& .MuiDataGrid-columnHeaders': {
            backgroundColor: '#fafafa',
            borderBottom: '2px solid #e0e0e0'
          }
        }}
      />
    </Paper>
  );
};