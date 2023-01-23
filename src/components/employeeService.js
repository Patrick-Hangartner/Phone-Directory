import axios from 'axios';

class EmployeeService {

    async getAllEmployees() {
        try {
            const response = await axios.get('http://localhost:7142/api/employee');
            if (response.status === 200) {
                return response.data;
            } else {
                throw new Error(response.statusText);
            }
        } catch (error) {
            console.error(error);
            throw error;
        }
    }

    async searchEmployees(searchTerm) {
        try {
            const response = await axios.get(`http://localhost:7142/api/employee/search?searchTerm=${searchTerm}`);
            if (response.status === 200) {
                return response.data;
            } else {
                throw new Error(response.statusText);
            }
        } catch (error) {
            console.error(error);
            throw error;
        }
    }
        async insertEmployee(employee) {
            try {
                const response = await axios.post('http://localhost:7142/api/employee', employee);
                if (response.status === 201) {
                    return response.data;
                } else {
                    throw new Error(response.statusText);
                }
            } catch (error) {
                console.error(error);
                throw error;
            }
        }
    
        async deleteEmployee(id) {
            try {
                const response = await axios.delete(`http://localhost:7142/api/employee/${id}`);
                if (response.status === 200) {
                    return response.data;
                } else {
                    throw new Error(response.statusText);
                }
            } catch (error) {
                console.error(error);
                throw error;
            }
        }
    
        async updateEmployee(employee) {
            try {
                const response = await axios.put(`http://localhost:7142/api/employee/${employee.id}`, employee);
                if (response.status === 200) {
                    return response.data;
                } else {
                    throw new Error(response.statusText);
                }
            } catch (error) {
                console.error(error);
                throw error;
            }
        }
    
}
export default EmployeeService;



